using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlashForgeMonitor.api.client.klipper;
using FlashForgeMonitor.api.util;

namespace FlashForgeMonitor.ui
{
    public partial class MoonrakerUI : Form
    {
        private string _ip;
        private MoonrakerClient _client;
        
        public MoonrakerUI(string ip)
        {
            _ip = ip;
            InitializeComponent();
        }

        private async void MoonrakerUI_Load(object sender, EventArgs e)
        {
            _client = new MoonrakerClient(_ip);
            await StartSync();
        }

        private CancellationTokenSource _cts;
        private async Task StartSync()
        {
            _cts = new CancellationTokenSource();

            //await Task.Delay(1000);
            var printStats = await _client.GetPrintStats();
            //await Task.Delay(50);
            var printerInfo = await _client.GetPrinterInfo();
            
            FileNameLabel.Text = printStats != null ? $"Current file: {printStats.Filename}" : "Current file: None";
            HostNameLabel.Text = printerInfo != null ? printerInfo.Hostname : "Unknown host";
            
            await Task.Run(async () =>
            {
                while (!_cts.IsCancellationRequested)
                {
                    if (_client == null) break;
                    
                    // get data from moonraker
                    var ps = await _client.GetPrintStats();
                    var sd = await _client.GetVirtualSd();
                    var chamberFan = await _client.GetChamberFan();
                    var controllerFan = await _client.GetControllerFan();
                    var internalFan = await _client.GetInternalFan();
                    var externalFan = await _client.GetExternalFan();
                    var partFan = await _client.GetPartFan();
                    var loadCell = await _client.GetLoadCell();
                    var tvoc = await _client.GetTvocLevel();
                    var extruderT = await _client.GetExtruderTemp();
                    var bedT = await _client.GetBedTemp();
                    
                    // populate the ui
                    if (ps != null)
                    {
                        var fg = await _client.GetCurrentFilamentUsedStats();
                        SetLabel(FilamentUsedLabel, fg == null ? $"Filament used: err)" : $"Filament used: {fg})");
                        SetLabel(PrintTimeLabel, "Print time: " + TimeSpan.FromSeconds(ps.PrintDuration).ToString(@"hh\:mm"));
                        SetLabel(StatusLabel, $"Status: {ps.State}");
                    }
                    else
                    {
                        SetLabel(FilamentUsedLabel, "Filament used: error");
                        SetLabel(PrintTimeLabel, "Print time: error");
                        SetLabel(StatusLabel, "Status: error");
                    }
                    
                    if (sd != null)
                    {
                        int progress;
                        if (sd.Progress == 1.0) progress = 100;
                        else progress = (int) Math.Round(sd.Progress * 100);
                        SetProgressBar(PrintProgressBar, progress);
                        SetLabel(PrintProgressLabel, $"Progress: {progress}%");
                    }
                    else SetLabel(PrintProgressLabel, "Progress: err");
                    
                    if (extruderT != null) SetLabel(ExtruderTempLabel, extruderT.IsHeating() ? $"Extruder: {extruderT.GetCurrent()}/{extruderT.GetTarget()}C" : $"Extruder: {extruderT.GetCurrent()}C");
                    else SetLabel(ExtruderTempLabel, "Extruder: err");
                    
                    if (bedT != null) SetLabel(BedTempLabel, bedT.IsHeating() ? $"Print bed: {bedT.GetCurrent()}/{bedT.GetTarget()}C" : $"Print bed: {bedT.GetCurrent()}C");
                    else SetLabel(BedTempLabel, "Print bed: err");
                    
                    SetLabel(ChamberFanLabel, chamberFan != null ? $"Chamber fan: {chamberFan.GetSpeed()}%" : "Chamber fan: err");
                    SetLabel(ControllerFanLabel, controllerFan != null ? $"Controller fan: {controllerFan.GetSpeed()}%" : "Controller fan: err");
                    SetLabel(InternalFanLabel, internalFan != null ? $"Internal fan: {internalFan.GetSpeed()}%" : "Internal fan: err");
                    SetLabel(ExternalFanLabel, externalFan != null ? $"External fan: {externalFan.GetSpeed()}%" : "External fan: err");
                    SetLabel(PartFanLabel, partFan != null ? $"Part fan: {partFan.GetSpeed()}%" : "Part fan: err");
                    SetLabel(LoadCellLabel, loadCell != null ? $"Load cell: {loadCell.GetValue()}" : "err");
                    SetLabel(TvocLabel, tvoc != null ? $"TVOC: {tvoc.GetValue()}" : "TVOC: err");
                    
                    // don't send requests continuously 
                    await Task.Delay(1000);
                }
            }, _cts.Token);
        }

        private async Task StopSync()
        {
            _cts.Cancel();
        }

        
        
        private static void SetLabel(Label label, string text)
        { // thread safe label update
            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() =>
                {
                    label.Text = text;
                }));
            }
            else label.Text = text;
        }

        private static void SetProgressBar(ProgressBar bar, int value)
        { // thread safe progress bar update
            if (bar.InvokeRequired)
            {
                bar.Invoke(new Action(() =>
                {
                    bar.Value = value;
                }));
            }
            else bar.Value = value;
        }

        private void PartFanLabel_Click(object sender, EventArgs e)
        {
            
            
            
        }
    }
}