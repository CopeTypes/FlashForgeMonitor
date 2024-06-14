using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace FlashForgeMonitor.api.util
{
    /**
     * Automatically find FlashForge printers on the network
     */
    public class PrinterScanner
    {
        private const string Host = "192.168.0.1";
        
        public static async Task<string> FindPrinter()
        {
            var tasks = new List<Task<ScanResult>>();
            for (var i = 199; i < 215; i++)
            {
                var ip = Host.Substring(0, Host.Length - 1) + i;
                tasks.Add(Task.Run(async () => await IsPrinter(ip, "8080")));
            }

            var sw = new Stopwatch();
            sw.Start();
            var results = await Task.WhenAll(tasks);
            sw.Stop();
            Debug.WriteLine("FindPrinter took " + sw.ElapsedMilliseconds + "ms");
            return (from result in results where result.Valid select result.Ip).FirstOrDefault();
        }

        private static async Task<ScanResult> IsPrinter(string ip, string port)
        {
            var streamUrl = $"http://{ip}:{port}/?action=stream"; // adm 5 should have the same url under klipper
            //ip::7125/printer/info for klipperPrinPr;PP{P
            
            // todo find a way to filter out non-stock firmware
            var scanResult = new ScanResult
            {
                Valid = false,
                Ip = ip
            };

            try
            {
                
                var request = WebRequest.CreateHttp(streamUrl);
                //request.Timeout doesn't work when async, so handle the waiting here
                var result = request.BeginGetResponse(null, null);
                if (!result.AsyncWaitHandle.WaitOne(500))
                { // takes ~2.8 seconds at 1000, ~1.4 at 500. Need to do further testing for speed/reliability combo
                    request.Abort();
                    return scanResult;
                }

                var response = (HttpWebResponse) request.EndGetResponse(result);
                var contentType = response.ContentType;
                if (!contentType.Contains("multipart/x-mixed-replace") || response.StatusCode != HttpStatusCode.OK)
                    return scanResult;
                scanResult.Valid = true;
                return scanResult;
                
            }
            catch (WebException e)
            {
                if (e.InnerException is SocketException sockErr)
                {
                    Debug.WriteLine("Socket err: " + sockErr.Message);
                }
                else
                {
                    Debug.WriteLine("Web exception: " + e.Message);
                }
                return scanResult;
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("Request timed out to: " + ip);
                return scanResult;
            }
        }

        private class ScanResult
        {
            public bool Valid { get; set; }
            public string Ip { get; set; }
        }
    }
}
