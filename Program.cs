using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlashForgeMonitor.api.client;
using FlashForgeMonitor.api.client.replays;
using FlashForgeMonitor.api.util;
using FlashForgeMonitor.ui;

namespace FlashForgeMonitor
{
    internal static class Program
    {
        [DllImport( "kernel32.dll" )]
        private static extern bool AttachConsole( int dwProcessId );

        private static readonly object consoleLock = new object();

        [STAThread]
        private static async Task Main()
        {
            AttachConsole(-1);

            /*var sw = new Stopwatch();
            sw.Start();
            var printerIp = await PrinterScanner.FindPrinter();
            if (printerIp != null)
            {
                Console.WriteLine("Found FlashForge printer @ " + printerIp);
                var client = new PrinterClient(printerIp);
                var info = new PrinterInfo().FromReplay(client.SendCommand("~M115"));
                sw.Stop();
                if (info != null) Console.WriteLine(info.ToString());
                Console.WriteLine("Executed in " + sw.ElapsedMilliseconds + "ms");
            }*/
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new MoonrakerUI("192.168.0.177"));


        }

        public static Task Log(string msg)
        {
            lock (consoleLock)
            {
                Console.WriteLine(msg);
            }

            return Task.CompletedTask;
        }
    }
}