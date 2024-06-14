using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FlashForgeMonitor.api.client.klipper
{
    // https://moonraker.readthedocs.io/en/latest/web_api/
    
    public class MoonrakerClient
    {


        private readonly HttpClient _client;
        private readonly string _ip;
        private readonly string _baseUrl;

        private const string InfoEndpoint = "/printer/info";
        private const string ServerInfoEndpoint = "/server/info";
        private const string QueryEndpoint = "/printer/objects/query?";
        private const string ObjectListEndpoint = "/printer/objects/list";

        private const string EmergencyStopEndpoint = "/printer/emergency_stop";
        private const string RestartServerEndpoint = "/server/restart"; // all these return "ok"
        private const string RestartHostEndpoint = "/printer/restart";
        private const string RestartFirmwareEndpoint = "/printer/firmware_restart";
        private const string ShutdownEndpoint = "/machine/shutdown"; // full shutdown no request return
        private const string RebootEndpoint = "/machine/reboot"; // no request return

        private const string StartServiceEndpoint = "/machine/services/start?service=";
        private const string StopServiceEndpoint = "/machine/services/stop?service=";
        private const string RestartServiceEndpoint = "/machine/services/restart?service=";
        
        
        //https://moonraker.readthedocs.io/en/latest/web_api/#gcode-apis
        private const string SendGCodeEndpoint = "/printer/gcode/script?script=";

        private const string GetGCodeHelpEndpoint = "/printer/gcode/help"; // todo impl

        private const string PrintFileEndpoint = "/printer/print/start?filename=";
        private const string PausePrintEndpoint = "/printer/print/pause";
        private const string ResumePrintEndpoint = "/printer/print/resume";
        private const string CancelPrintEndpoint = "/printer/print/cancel";
        
        //https://moonraker.readthedocs.io/en/latest/web_api/#file-upload
        
        

        // fans
        private const string ControllerFan = "controller_fan stepper_driver_fan";
        private const string ChamberFan = "fan_generic chamber_fan";
        private const string InternalFan = "fan_generic internal_fan";
        private const string ExternalFan = "fan_generic external_fan";
        private const string PartFan = "fan";
        
        // temp sensors
        private const string LoadCell = "temperature_sensor Load_Cell";
        private const string TvocLevel = "temperature_sensor TVOC_Level";

        
        public MoonrakerClient(string printerIp)
        {
            _ip = printerIp;
            _baseUrl = $"http://{_ip}:7125";
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromSeconds(1500);
        }

        public async Task<bool> Verify()
        { // make sure the connection is good
            var sysinfo = await GetMoonrakerInfo();
            return sysinfo != null && sysinfo.KlippyConnected;
        }


        private async Task<string> GetRequest(string url)
        { // handle basic http requests to moonraker
            try
            {
                Debug.WriteLine("MoonrakerClient GetRequest with url: " + url);
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Debug.WriteLine("Response is OK!");
                var data = await response.Content.ReadAsStringAsync();
                Debug.WriteLine("Data: " + data);
                return data;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("MoonrakerAPI GetRequest error with url: " + url);
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }

        private async Task<List<string>> GetObjectList()
        { // gets all available objects
            var data = await GetRequest(_baseUrl + ObjectListEndpoint);
            if (data == null) return null;

            var jdata = JsonConvert.DeserializeObject<dynamic>(data);
            if (jdata == null || jdata["result"]["objects"] == null) return null;

            var list = new List<string>();
            foreach (var obj in jdata["result"]["objects"])
            { list.Add(obj.ToString()); }

            return list;

        }
        
        public async Task<List<string>> GetMacros()
        { // gets all klipper macros
            var objectList = await GetObjectList();
            return objectList == null ? null : (from obj in objectList where obj.StartsWith("gcode_macro ") select obj.Substring("gcode_macro ".Length)).ToList();
        }

        private async Task<T> GetQuery<T>(string query) where T : class
        { // get an instance of class from query
            var json = await RequestQuery(query);
            return json == null ? null : JsonConvert.DeserializeObject<T>(json);
        }
        
        private async Task<T> GetType<T>(string endpoint) where T : class
        { // get an instance of class from endpoint
            Debug.WriteLine("GetType with endpoint: " + endpoint);
            var json = await GetRequest(endpoint);
            if (json == null) return null;
            var jjson = JsonConvert.DeserializeObject<dynamic>(json);
            if (jjson != null && jjson["result"] != null) return JsonConvert.DeserializeObject<T>(jjson["result"].ToString());
            Debug.WriteLine("MoonrakerClient GetType json response missing 'result' key");
            return null;
        }
        
        private async Task<string> RequestQuery(string query)
        { // extract the query sub-json from moonraker's response
            var url = _baseUrl + QueryEndpoint;
            if (query.Contains(" ")) url += WebUtility.UrlEncode(query);
            else url += query;
            

            var data = await GetRequest(url);
            if (data == null)
            {
                Debug.WriteLine("MoonrakerClient RequestQuery got null data");
                return null;
            }

            if (query.Contains("heater_bed")) query = "heater_bed"; // the json is formatted a bit different since there's space in the query
            if (query.Contains("extruder")) query = "extruder";
            
            var json = JsonConvert.DeserializeObject<dynamic>(data);
            if (json != null && json["result"]["status"][query] != null)
                return JsonConvert.SerializeObject(json["result"]["status"][query]).ToString();
            return null;
        }

        public async Task<PrinterInfo> GetPrinterInfo()
        { return await GetType<PrinterInfo>(_baseUrl + InfoEndpoint); }
        
        public async Task<ToolheadInfo> GetToolheadInfo()
        { return await GetQuery<ToolheadInfo>("toolhead"); }

        public async Task<PrintStats> GetPrintStats()
        { return await GetQuery<PrintStats>("print_stats"); }

        public async Task<TempInfo> GetBedTemp()
        { return await GetQuery<TempInfo>("heater_bed=target,temperature"); }

        public async Task<TempInfo> GetExtruderTemp()
        { return await GetQuery<TempInfo>("extruder=target,temperature"); }

        public async Task<FanInfo> GetChamberFan()
        { return await GetQuery<FanInfo>(ChamberFan); }

        public async Task<FanInfo> GetControllerFan()
        { return await GetQuery<FanInfo>(ControllerFan); }
        
        public async Task<FanInfo> GetInternalFan()
        { return await GetQuery<FanInfo>(InternalFan); }
        
        public async Task<FanInfo> GetExternalFan()
        { return await GetQuery<FanInfo>(ExternalFan); }
        
        public async Task<FanInfo> GetPartFan()
        { return await GetQuery<FanInfo>(PartFan); }

        public enum FanType
        {
            Chamber, Controller, Internal, External, Part
        }

        public async Task<FilamentSensorData> GetFilamentSensorInfo()
        { return await GetQuery<FilamentSensorData>("filament_switch_sensor runout_sensor"); }

        public async Task<bool> FilamentRunout()
        {
            var d = await GetFilamentSensorInfo();
            return d.FilamentDetected;
        }

        public async Task<TempSensor> GetLoadCell()
        { return await GetQuery<TempSensor>(LoadCell); }
        
        public async Task<TempSensor> GetTvocLevel()
        { return await GetQuery<TempSensor>(TvocLevel); }

        public async Task<VirtualSdInfo> GetVirtualSd()
        { return await GetQuery<VirtualSdInfo>("virtual_sdcard"); }

        public async Task<MoonrakerSystemInfo> GetMoonrakerInfo()
        { return await GetType<MoonrakerSystemInfo>(_baseUrl + ServerInfoEndpoint); }

        private async Task<string> PostEndpoint(string endpoint, string payload)
        { // handle post request to moonraker
            var url = _baseUrl + endpoint;
            if (payload != null) url += payload;
            
            try
            {
                var response = await _client.PostAsync(url, null);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            } catch (Exception ex)
            {
                Debug.WriteLine("Moonraker API error posting endpoint: " + endpoint);
                if (payload != null) Debug.WriteLine("Payload: " + payload);
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }

        private async Task<bool> PostEndpointOk(string endpoint, string payload)
        {
            var response = await PostEndpoint(endpoint, payload);
            return response != null && response.Contains("ok");
        }

        public async Task EmergencyStop()
        { await PostEndpoint(EmergencyStopEndpoint, null); }
        
        public async Task ShutdownMachine()
        { await PostEndpoint(ShutdownEndpoint, null); }
        
        public async Task RebootMachine()
        { await PostEndpoint(RebootEndpoint, null); }

        public async Task<bool> RestartServer()
        { return await PostEndpointOk(RestartServerEndpoint, null); }
        
        public async Task<bool> RestartHost()
        { return await PostEndpointOk(RestartHostEndpoint, null); }
        
        public async Task<bool> RestartFirmware()
        { return await PostEndpointOk(RestartFirmwareEndpoint, null); }
        
        public async Task<bool> StartService(string name)
        { return await PostEndpointOk(StartServiceEndpoint, name); }
        
        public async Task<bool> StopService(string name)
        { return await PostEndpointOk(StopServiceEndpoint, name); }
        
        public async Task<bool> RestartService(string name)
        { return await PostEndpointOk(RestartServiceEndpoint, name); }

        public async Task<bool> SetPartFan(int speed)
        {
            if (speed > 255) speed = 255;
            return await SendGCode("M106 S" + speed);
        }

        public async Task<bool> SetInternalFan(int speed)
        { return await SetGenericFan(speed, "internal_fan"); }

        public async Task<bool> SetExternalFan(int speed)
        { return await SetGenericFan(speed, "external_fan"); }

        public async Task<bool> SetChamberFan(int speed)
        { return await SetGenericFan(speed, "chamber_fan"); }
        
        private async Task<bool> SetGenericFan(int speed, string name)
        { return await SendGCode($"SET_FAN_SPEED FAN={name} SPEED={speed * 0.1}"); }
        
        public async Task<bool> SendGCode(string gcode)
        { return await PostEndpointOk(SendGCodeEndpoint, gcode); }

        public async Task<bool> SendGCodeScript(List<string> script)
        {
            foreach (var gcode in script)
            {
                if (!await SendGCode(gcode)) return false;
            }

            return true;
        }
        
        //todo gcode help endpoint : https://moonraker.readthedocs.io/en/latest/web_api/#get-gcode-help
        
        public async Task<bool> StartPrint(string filename)
        { return await PostEndpointOk(PrintFileEndpoint, filename); }
        
        public async Task<bool> CancelPrint()
        { return await PostEndpointOk(CancelPrintEndpoint, null); }
        
        public async Task<bool> PausePrint()
        { return await PostEndpointOk(PausePrintEndpoint, null); }
        
        public async Task<bool> ResumePrint()
        { return await PostEndpointOk(ResumePrintEndpoint, null); }

        public async Task<bool> HomeAxes() // you can specify the axes to home, but it still homes them all anyway
        { return await SendGCode("G28"); }

        public async Task<bool> TurnMotorsOff()
        { return await SendGCode("M84"); }

        public async Task<bool> TurnLcdOff()
        { return await SendGCode("LCD_OFF"); }

        public async Task<bool> TurnLcdOn()
        { return await SendGCode("LCD_ON"); }

        /// <summary>
        /// Reboots back into FlashForge stock firmware.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RebootToStock()
        { return await SendGCode("REBOOT_STOCK_SYSTEM"); }

        /// <summary>
        /// Only calibrates the bed mesh, without doing the heating/nozzle clean sequence
        /// </summary>
        /// <returns></returns>
        public async Task<bool> LevelBedQuick()
        { return await SendGCode("BED_MESH_CALIBRATE"); }

        /// <summary>
        /// Does 'full' bed leveling - heat the bed and clean the nozzle
        /// </summary>
        /// <returns></returns>
        public async Task<bool> LevelBed()
        { return await SendGCode("AUTO_BED_LEVEL"); }

        // i could be wrong but it doesn't appear/sound like that the klipper firmware turns one off after switching to the other
        // so keep track of which filtering is active, and stop all filtering + start again to ensure only one is running
        private bool intFilter;
        public async Task<bool> StartInternalFiltering()
        {
            intFilter = true;
            if (!extFilter) return await SendGCode("AIR_CIRCULATION_INTERNAL");
            await StopFiltering();
            extFilter = false;
            return await SendGCode("AIR_CIRCULATION_INTERNAL");
        }

        private bool extFilter;
        public async Task<bool> StartExternalFiltering()
        {
            extFilter = true;
            if (!intFilter) return await SendGCode("AIR_CIRCULATION_EXTERNAL");
            await StopFiltering();
            intFilter = false;
            return await SendGCode("AIR_CIRCULATION_EXTERNAL");
        }

        public async Task<bool> StopFiltering()
        {
            return await SendGCode("AIR_CIRCULATION_STOP");
        }
        
        public class PrinterInfo
        {
            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("state_message")]
            public string StateMessage { get; set; }

            [JsonProperty("hostname")]
            public string Hostname { get; set; }

            [JsonProperty("klipper_path")]
            public string KlipperPath { get; set; }

            [JsonProperty("python_path")]
            public string PythonPath { get; set; }

            [JsonProperty("log_file")]
            public string LogFile { get; set; }

            [JsonProperty("config_file")]
            public string ConfigFile { get; set; }

            [JsonProperty("software_version")]
            public string SoftwareVersion { get; set; }

            [JsonProperty("cpu_info")]
            public string CpuInfo { get; set; }
        }
        
        public class TempInfo
        { 
            [JsonProperty("target")]
            public double TargetTemperature { get; set; }

            [JsonProperty("temperature")]
            public double CurrentTemperature { get; set; }

            public bool IsHeating()
            { return TargetTemperature != 0.0; }

            public int GetTarget()
            {
                if (TargetTemperature == 0.0) return 0; 
                return (int)Math.Round(TargetTemperature);
            }

            public int GetCurrent()
            {
                if (CurrentTemperature == 0.0) return 0;
                return (int)Math.Round(CurrentTemperature);
            }
        }

        public class TempSensor
        {
            [JsonProperty("temperature")]
            public double Temperature { get; set; }
            
            [JsonProperty("measured_min_temp")]
            public double MeasuredMin { get; set; }
            
            [JsonProperty("measured_max_temp")]
            public double MeasuredMax { get; set; }

            public int GetValue()
            {
                return (int)Math.Round(Temperature);
            }
        }

        public class FanInfo
        {
            [JsonProperty("speed")]
            public double Speed { get; set; }

            [JsonProperty("rpm")]
            public object Rpm { get; set; }

            public int GetSpeed()
            {
                return (int)Math.Round(Speed * 100);
            }
        }
        
        public class ToolheadInfo
        {
            [JsonProperty("homed_axes")]
            public string HomedAxes { get; set; }

            public bool IsHomed()
            { return HomedAxes.Contains("xyz"); }

            [JsonProperty("print_time")]
            public double PrintTime { get; set; }

            [JsonProperty("estimated_print_time")]
            public double EstimatedPrintTime { get; set; }

            [JsonProperty("extruder")]
            public string Extruder { get; set; }

            [JsonProperty("position")]
            public double[] Position { get; set; }

            [JsonProperty("max_velocity")]
            public double MaxVelocity { get; set; }

            [JsonProperty("max_accel")]
            public double MaxAcceleration { get; set; }

            [JsonProperty("max_accel_to_decel")]
            public double MaxAccelerationToDeceleration { get; set; }

            [JsonProperty("square_corner_velocity")]
            public double SquareCornerVelocity { get; set; }
        }
        
        public class FilamentSensorData
        {
            [JsonProperty("filament_detected")]
            public bool FilamentDetected { get; set; }

            [JsonProperty("enabled")]
            public bool Enabled { get; set; }
        }
        
        
        public class PrintStats
        {
            [JsonProperty("filename")]
            public string Filename { get; set; }

            /// <summary>
            /// The total time (in seconds) elapsed since a print has started. This includes time spent paused.
            /// </summary>
            [JsonProperty("total_duration")]
            public double TotalDuration { get; set; }

            /// <summary>
            /// The total time (in seconds) elapsed since a print has started. This excludes time spent paused.
            /// </summary>
            [JsonProperty("print_duration")]
            public double PrintDuration { get; set; }

            /// <summary>
            /// The amount of filament used during the current print (in mm). Any extrusion during a pause is excluded.
            /// </summary>
            [JsonProperty("filament_used")]
            public double FilamentUsed { get; set; }

            public int GetFilamentMetersUsed()
            {
                return (int)Math.Round(FilamentUsed / 1000);
            }

            /// <summary>
            /// The current print state. See PrintState
            /// </summary>
            [JsonProperty("state")]
            public string State { get; set; }

            /// <summary>
            /// Contains the error message when an error is detected, otherwise null.
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// Contains the layer information (if set by the slicer)
            /// </summary>
            [JsonProperty("info")]
            public PrintStatsLayerInfo LayerInfo { get; set; }

            public PrintState GetState()
            {
                switch (State)
                {
                    case "standby": return PrintState.Standby;
                    case "printing": return PrintState.Printing;
                    case "paused": return PrintState.Paused;
                    case "complete": return PrintState.Complete;
                    case "cancelled": return PrintState.Cancelled;
                    case "error": return PrintState.Error;
                }

                return PrintState.ApiError;
            }
        }

        public class PrintStatsLayerInfo
        {
            [JsonProperty("total_layer")]
            public object TotalLayer { get; set; }

            [JsonProperty("current_layer")]
            public object CurrentLayer { get; set; }

            public int GetTotalLayers()
            {
                if (TotalLayer != null) return (int)TotalLayer;
                return -1;
            }

            public int GetCurrentLayer()
            {
                if (CurrentLayer != null) return (int)CurrentLayer;
                return -1;
            }

            public int GetLayersLeft()
            {
                var current = GetCurrentLayer();
                var total = GetTotalLayers();
                if (current == -1 || total == -1) return -1;
                return total - current;
            }

            public bool Available() // depending on the firmware settings and/or slicer, layer data is not always set
            { return TotalLayer != null && CurrentLayer != null; }
        }

        public class VirtualSdInfo
        {
            [JsonProperty("file_path")]
            public string FilePath { get; set; }
            
            /// <summary>
            /// The print progress reported as a percentage of the file read, in the range of 0.0 - 1.0.
            /// </summary>
            [JsonProperty("progress")]
            public double Progress { get; set; }
            
            /// <summary>
            /// Returns true if the virtual sdcard is currently processing a file. Note that this will return false if a virtual sdcard print is paused.
            /// </summary>
            [JsonProperty("is_active")]
            public bool IsActive { get; set; }
            /// <summary>
            /// The current file position in bytes. This will always be an integer value
            /// </summary>
            [JsonProperty("file_position")]
            public int FilePosition { get; set; }
            /// <summary>
            /// The current file total size in bytes. Undocumented.
            /// </summary>
            [JsonProperty("file_size")]
            public int FileSize { get; set; }
        }
        

        public enum PrintState
        {
            Standby,
            Printing,
            Paused,
            Complete,
            Cancelled,
            Error,
            ApiError
        }
        
        public class MoonrakerSystemInfo
        {
            [JsonProperty("klippy_connected")]
            public bool KlippyConnected { get; set; }

            [JsonProperty("klippy_state")]
            public string KlippyState { get; set; }

            [JsonProperty("components")]
            public List<string> Components { get; set; }

            [JsonProperty("failed_components")]
            public List<string> FailedComponents { get; set; }

            [JsonProperty("registered_directories")]
            public List<string> RegisteredDirectories { get; set; }

            [JsonProperty("warnings")]
            public List<string> Warnings { get; set; }

            [JsonProperty("websocket_count")]
            public int WebsocketCount { get; set; }

            [JsonProperty("moonraker_version")]
            public string MoonrakerVersion { get; set; }

            [JsonProperty("api_version")]
            public List<int> ApiVersion { get; set; }

            [JsonProperty("api_version_string")]
            public string ApiVersionString { get; set; }
        }
    }
}