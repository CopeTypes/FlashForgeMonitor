using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlashForgeMonitor.api.client;
using FlashForgeMonitor.api.client.klipper;
using FlashForgeMonitor.api.client.replays;
using FlashForgeMonitor.api.util;

namespace FlashForgeMonitor
{
    public partial class Form1 : Form
    {
        private FlashForgeClient _client;
        private string _ip;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //await initUI();
        }
        
        private async Task initUI()
        {
            var sw = new Stopwatch();
            sw.Start();
            statusLabel.Text = "Looking for FlashForge printers...";
            var autoIp = await PrinterScanner.FindPrinter(); // auto scan for printers first
            if (autoIp != null)
            {
                statusLabel.Text = "Auto-connecting to printer @ " + autoIp;
                _client = new FlashForgeClient(autoIp);
                _ip = autoIp;
            }
            else
            { // prompt for a printer ip + hold for valid connection
                statusLabel.Text = "No FlashForge printers found.";
                MessageBox.Show("No FlashForge printers were automatically found\nPress OK to set the printer IP.");
                while (true)
                {
                    if (await ConnectToIP()) break;
                    MessageBox.Show("Failed to connect! Please check the ip and try again");
                }

                statusLabel.Text = "Connecting to printer @ " + _ip;
            }

            await Task.Delay(1000);
            
            // Get data from printer & populate UI
            var mi = await _client.GetPrinterInfo();
            var ti = await _client.GetTempInfo();
            var pi = await _client.GetEndstopInfo();
            var pri = await _client.GetPrintStatus();

            if (mi != null) Text = mi.TypeName + " @  " + _ip;
            
            SetMachineInfo(mi, mi == null);
            SetTempInfo(ti,  ti == null);
            SetPrintInfo(pi, pi == null);
            SetPrintProgress(pri);

            sw.Stop();
            Console.WriteLine("UI Init took " + sw.ElapsedMilliseconds + "ms");
            await StartPrinterUpdates(); // start ui update thread
        }
        
        
        private void SetMachineInfo(PrinterInfo info, bool error)
        {
            if (info == null) error = true;
            if (error)
            {
                machineTypeLabel.Text = "Machine: err";
                snLabel.Text = "Serial Number: err";
                fwVersionLabel.Text = "Firmware Version: err";
                macLabel.Text = "MAC Address: err";
                toolsLabel.Text = "Tool Heads: err";
                return;
            }
            machineTypeLabel.Text = "Machine: " + info.TypeName;
            snLabel.Text = "Serial Number: " + info.SerialNumber;
            fwVersionLabel.Text = "Firmware Version: " + info.FirmwareVersion;
            macLabel.Text = "MAC Address: " + info.MacAddress;
            toolsLabel.Text = "Tool Heads: " + info.ToolCount;
        }

        private void SetTempInfo(TempInfo info, bool error)
        {
            if (info == null) error = true;
            if (error)
            {
                bedTempLabel.Text = "Print Bed Temp: ???";
                extTempLabel.Text = "Extruder Temp: ???";
                return;
            }
            bedTempLabel.Text = "Print Bed Temp: " + info.GetBedTemp().GetFull();
            extTempLabel.Text = "Extruder Temp: " + info.GetExtruderTemp().GetFull();
        }

        private void SetPrintProgress(PrintStatus pi)
        {
            //var pi = await _client.GetPrintStatus();
            if (pi != null)
                progressLabel.Text = "Print Progress: " + pi.GetLayerProgress() + " (" + pi.GetPrintPercent() + "%)";
            else progressLabel.Text = "Print Progress: Unknown";
        }
        
        private void SetPrintInfo(EndstopStatus info, bool error)
        {
            if (info == null) error = true;
            if (error)
            {
                statusLabel.Text = "Communication error...";
                ledStatusLabel.Text = "???";
                return;
            }
            if (info.IsPrinting())
            {
                var job = "a local print job";
                if (info._CurrentFile != null) job = info._CurrentFile;
                statusLabel.Text = "Working on " + job + " ...";
            }
            else if (info.IsPrintComplete())
            {
                if (info._CurrentFile != null)
                    statusLabel.Text = "Finished printing " + info._CurrentFile + " !";
                else statusLabel.Text = "Finished local print job!";
            }
            else if (info.IsReady()) statusLabel.Text = "Idle, ready for job";
            else if (info.IsPaused())
            {
                if (info._CurrentFile != null)
                    statusLabel.Text = "Printing paused, working on" + info._CurrentFile + " .";
                else statusLabel.Text = "Printing paused, working on local print job.";
            }

            ledStatusLabel.Text = info._LedEnabled ? "Interior lights: ON" : "Interior lights: OFF";
        }

        
        
        private async Task<bool> ConnectToIP()
        {
            var prompt = new ConnectPrompt();
            prompt.Show();
            
            
            var ip = prompt.Text;
            prompt.Dispose();
            if (ip == null) return false;

            statusLabel.Text = "Trying to connect to " + ip;
            try
            {
                _client = new FlashForgeClient(ip);
                _ip = ip;
                if (!await _client.Validate()) return false;
                var p = await _client.GetPrinterInfo();
                SetMachineInfo(p, p == null);
                return true;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Unable to create printer client instance with user-provided ip: " + ip);
                Debug.WriteLine(e.StackTrace);
                return false;
            }
        }
        
        private CancellationTokenSource _cts;
        
        private async Task StartPrinterUpdates()
        {
            _cts = new CancellationTokenSource();

            await Task.Delay(1000);
            await Task.Run(async () =>
            {
                while (!_cts.IsCancellationRequested)
                {
                    if (_client == null) break;
                    //var info = await _client.GetPrinterInfo();
                    var printInfo = await _client.GetEndstopInfo();
                    var tempInfo = await _client.GetTempInfo();
                    SetPrintInfo(printInfo, printInfo == null);
                    SetTempInfo(tempInfo, tempInfo == null);
                    await Task.Delay(1500);
                }
            }, _cts.Token);
        }

        private void StopPrinterUpdates()
        {
            _cts?.Cancel();
        }
        
        private async void ledOffButton_Click(object sender, EventArgs e)
        {
            await _client.TurnLightsOff();
        }

        private async void ledOnButton_Click(object sender, EventArgs e)
        {
            await _client.TurnLightsOn();
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            var client = new MoonrakerClient("192.168.0.177");
            var printerInfo = await client.GetPrinterInfo();
            if (printerInfo != null) Console.WriteLine(printerInfo.State);
        }
    }
}