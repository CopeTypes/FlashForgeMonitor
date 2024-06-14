using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FlashForgeMonitor.api.client.replays;
using FlashForgeMonitor.api.util;

namespace FlashForgeMonitor.api.client
{
    public class FlashForgeClient : FlashForgeTcpClient
    {
        public readonly string CmdLogin = "~M601 S1";
        public readonly string CmdLogout = "~M602";

        private const string CmdPrintStatus = "~M27";
        private const string CmdEndstopInfo = "~M119";
        private const string CmdInfoStatus = "~M115";
        private const string CmdInfoXyzab = "~M114";
        private const string CmdTemp = "~M105";

        private const string CmdLedOn = "~M146 r255 g255 b255 F0";
        private const string CmdLedOff = "~M146 r0 g0 b0 F0";

        private const string CmdPrintStart = "~M23 0:/user/%%filename%%\r";
        private const string CmdPrintStop = "~M26";

        public readonly string CmdStartTransfer = "~M28 %%size%% 0:/user/%%filename%%\r";
        private const string CmdSaveFile = "~M29\r";


        private CancellationTokenSource _cts;
        
        public FlashForgeClient(string hostname) : base(hostname)
        {
            
        }

        public string GetIp()
        {
            return hostname;
        }

        
        // these will be used for the ui once it's more polished, to avoid flooding the printer with requests
        private EndstopStatus _cachedEndstopStatus;
        private LocationInfo _cachedLocationInfo;
        //private PrinterInfo _cachedPrinterInfo;
        private TempInfo _cachedTempInfo;
        
        public async Task StartCache()
        {
            _cts = new CancellationTokenSource();

            await Task.Run(async () =>
            {
                while (!_cts.IsCancellationRequested)
                {
                    _cachedEndstopStatus = await GetEndstopInfo();
                    _cachedLocationInfo = await GetLocationInfo();
                    _cachedTempInfo = await GetTempInfo();
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }, _cts.Token);
        }

        public EndstopStatus GetEndstopStatusCached()
        {
            return _cachedEndstopStatus;
        }

        public LocationInfo GetLocationInfoCached()
        {
            return _cachedLocationInfo;
        }

        public TempInfo GetTempInfoCached()
        {
            return _cachedTempInfo;
        }

        public void Shutdown()
        {
            _cts?.Cancel();
            Dispose();
        }
        
        public async Task<bool> TurnLightsOff()
        {
            return await SendCmdOk(CmdLedOff);
        }

        public async Task<bool> TurnLightsOn()
        {
            return await SendCmdOk(CmdLedOn);
        }

        // ported the remaining code (for sending files + starting prints) 4/3/24
        // still needs to be tested
        
        
        /**
         * Transfer & saves a gcode file to the printer, and starts printing it
         */
        public async Task<bool> StartPrint(string file)
        {
            if (!File.Exists(file)) return false; // this should never happen
            if (!await TransferFile(file)) return false;
            return await SendStartPrint(Path.GetFileName(file));
        }

        /**
         * Transfers a gcode file to the printer's local storage
         */
        public async Task<bool> TransferFile(string file)
        {
            if (!File.Exists(file)) return false; // this should never happen
            var name = Path.GetFileName(file);
            try
            {
                var data = File.ReadAllBytes(file);
                if (!await InitFileTransfer(name, data.Length)) return false;
                var gcode = Utils.PrepareRawData(data);
                if (!await SendRawDataAsync(gcode)) return false;
                return await CompleteFileTransfer();
            } catch (IOException ioEx)
            {
                Debug.WriteLine("Unable to start print with file (IOException) : " + file);
                Debug.WriteLine(ioEx.StackTrace);
                return false;
            }
        }

        private async Task<bool> InitFileTransfer(string name, int length)
        {
            return await SendCmdOk(CmdPrintStart
                .Replace("%%size%%", length.ToString()
                .Replace("%%filename%%", name)));
        }

        private async Task<bool> CompleteFileTransfer()
        {
            return await SendCmdOk(CmdSaveFile);
        }

        private async Task<bool> SendStartPrint(string filename)
        {
            return await SendCmdOk(CmdPrintStart.Replace("%%filename%%", filename));
        }
        
        private async Task<bool> SendCmdOk(string cmd) // generic, not for use with all commands
        {
            var reply = await SendCommandAsync(cmd);
            return reply.Contains("Received.") && reply.Contains("ok");
        }
        
        // end ported code for sending files and shit

        public async Task<PrinterInfo> GetPrinterInfo()
        {
            return new PrinterInfo().FromReplay(await SendCommandAsync(CmdInfoStatus));
        }

        public async Task<TempInfo> GetTempInfo()
        {
            return new TempInfo().FromReplay(await SendCommandAsync(CmdTemp));
        }

        public async Task<EndstopStatus> GetEndstopInfo()
        {
            return new EndstopStatus().FromReplay(await SendCommandAsync(CmdEndstopInfo));
        }

        public async Task<PrintStatus> GetPrintStatus()
        {
            return new PrintStatus().FromReplay(await SendCommandAsync(CmdPrintStatus));
        }

        public async Task<LocationInfo> GetLocationInfo()
        {
            return new LocationInfo().FromReplay(await SendCommandAsync(CmdInfoXyzab));
        }

        public async Task<bool> Validate()
        {
            var info = await GetPrinterInfo();
            return info != null;
        }



        public async void StopPrinting()
        {
            await SendCommandAsync(CmdPrintStop);
        }
    }
}