using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlashForgeMonitor.api.client.klipper;

namespace FlashForgeMonitor.ui
{
    public partial class FanSpeedUI : Form
    {
        private readonly MoonrakerClient _client;
        private readonly MoonrakerClient.FanType _fanType;
        private readonly string _fanName;
        
        /// <summary>
        /// Simple UI for setting a fan's speed
        /// </summary>
        /// <param name="client">MoonrakerClient instance</param>
        /// <param name="fanType">What fan type is being controlled</param>
        /// <param name="fanName">Friendly name for the fan</param>
        public FanSpeedUI(MoonrakerClient client, MoonrakerClient.FanType fanType, string fanName)
        {
            InitializeComponent();
            _client = client;
            _fanType = fanType;
            _fanName = fanName;
        }

        private async Task<string> GetCurrentSpeed()
        {
            MoonrakerClient.FanInfo info;
            switch (_fanType)
            {
                case MoonrakerClient.FanType.Chamber:
                    info = await _client.GetChamberFan();
                    break;
                case MoonrakerClient.FanType.Controller:
                    info = await _client.GetControllerFan();
                    break;
                case MoonrakerClient.FanType.External:
                    info = await _client.GetExternalFan();
                    break;
                case MoonrakerClient.FanType.Internal:
                    info = await _client.GetInternalFan();
                    break;
                case MoonrakerClient.FanType.Part:
                    info = await _client.GetPartFan();
                    break;
                default: // this should never happen
                    throw new ArgumentOutOfRangeException();
            }

            return info?.GetSpeed().ToString();
        }

        private async void FanSpeedUI_Load(object sender, EventArgs e)
        {
            await SetCurrentSpeed();
        }

        private async Task SetCurrentSpeed()
        {
            var speed = await GetCurrentSpeed();
            SetLabel(FanNameLabel, speed != null ? $"{_fanName}: {speed}" : $"{_fanName}: err");
        }

        private async Task<bool> SetSpeed(int speed)
        {
            switch (_fanType)
            {
                case MoonrakerClient.FanType.Part:
                    return await _client.SetPartFan(speed);
                case MoonrakerClient.FanType.Internal:
                    return await _client.SetInternalFan(speed);
                case MoonrakerClient.FanType.External:
                    return await _client.SetExternalFan(speed);
                case MoonrakerClient.FanType.Chamber:
                    return await _client.SetChamberFan(speed);
                case MoonrakerClient.FanType.Controller: // controlled by firmware
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private static void SetLabel(Control label, string text)
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

        private async void SetSpeedButton_Click(object sender, EventArgs e)
        {
            ClearInput();
            try
            {
                var speed = int.Parse(SpeedInputBox.Text);
                if (speed < 0 || speed > 100)
                {
                    
                    MessageBox.Show("Invalid input, please input a speed from 0-100");
                    return;
                }

                if (!await SetSpeed(speed)) MessageBox.Show("Failed to set speed.");
            }
            catch (ArgumentNullException)
            { MessageBox.Show("Please input a speed from 0-100"); }
            catch (FormatException)
            { MessageBox.Show("Invalid input, please input a speed from 0-100"); }
            catch (OverflowException)
            { MessageBox.Show("Invalid input, please input a speed from 0-100"); }
        }

        private void ClearInput()
        {
            SetLabel(SpeedInputBox, "");
        }
    }
}