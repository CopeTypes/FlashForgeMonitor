using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Force.Crc32;

namespace FlashForgeMonitor.api.util
{
    public abstract class Utils { 
        private const int PacketSize = 4096;

        private static byte[] ConcatenateArrays(IReadOnlyCollection<byte> a, IReadOnlyCollection<byte> b) {
        var concat = new byte[a.Count + b.Count];
        var i = 0;
        foreach (var aa in a) { concat[i] = aa; i++; }
        foreach (var bb in b) { concat[i] = bb; i++; }
        return concat;
    }

    private static byte[] GeneratePrintPrePayload(int packetBundleCounter, int packetSize, string crc32Checksum, bool lastPackage)
    {
        var printPrePayload = new byte[] { 0x5a, 0x5a, 0xa5, 0xa5, // ZZ¥¥
                                               0x00, 0x00, 0x00, 0x00, // 4 bytes counter 
                                               0x00, 0x00, 0x10, 0x00, // packetSize full = 0x00 0x00 0x10 0x00 = 4096
                                               0x00, 0x00, 0x00, 0x00  // 4 bytes CRC32 checksum
                                             };

        AddPacketBundleCounter(packetBundleCounter, printPrePayload);
        AddPacketSize(packetSize, printPrePayload);
        AddChecksum(crc32Checksum, printPrePayload);

        return printPrePayload;
    }

    private static void AddPacketBundleCounter(int packetBundleCounter, IList<byte> printPrePayload)
    {
        var packetBundleCounterArray = BitConverter.GetBytes(packetBundleCounter);
        printPrePayload[4] = packetBundleCounterArray[0];
        printPrePayload[5] = packetBundleCounterArray[1];
        printPrePayload[6] = packetBundleCounterArray[2];
        printPrePayload[7] = packetBundleCounterArray[3];
    }

    private static void AddPacketSize(int packetSize, IList<byte> printPrePayload)
    {
        var packetSizeByteArray = BitConverter.GetBytes(packetSize);
        printPrePayload[8] = packetSizeByteArray[0];
        printPrePayload[9] = packetSizeByteArray[1];
        printPrePayload[10] = packetSizeByteArray[2];
        printPrePayload[11] = packetSizeByteArray[3];
    }

    private static void AddChecksum(string crc32Checksum, byte[] printPrePayload)
    {
        var decodeHex = new byte[crc32Checksum.Length / 2];
        for (var i = 0; i < crc32Checksum.Length; i += 2)
        {
            decodeHex[i / 2] = Convert.ToByte(crc32Checksum.Substring(i, 2), 16);
        }
        printPrePayload[15] = decodeHex[3];
        printPrePayload[14] = decodeHex[2];
        printPrePayload[13] = decodeHex[1];
        printPrePayload[12] = decodeHex[0];
    }

    private static string CalcChecksum(byte[] fileToPrintArray)
    {
        using (var memoryStream = new MemoryStream(fileToPrintArray))
        {
            using (var crc32 = new Crc32Algorithm())
            {
                var hash = crc32.ComputeHash(memoryStream);
                return BitConverter.ToString(hash).Replace("-", "").ToUpper();
            }
        }
    }

    public static List<byte[]> PrepareRawData(IEnumerable<byte> readAllLines)
    {
        var gcode = new List<byte[]>();

        var array = new byte[PacketSize];
        var i = 0;
        var packetCounter = 0;

        foreach (var b in readAllLines)
        {
            array[i] = b;
            i++;
            if (i != PacketSize) continue;
            var crc32Checksum = CalcChecksum(array);
            array = ConcatenateArrays(GeneratePrintPrePayload(packetCounter, i, crc32Checksum, false), array);
            packetCounter++;
            gcode.Add(array);
            i = 0;
            array = new byte[PacketSize];
        }
        var crc32ChecksumLast = CalcChecksum(array.Take(i).ToArray());
        array = ConcatenateArrays(GeneratePrintPrePayload(packetCounter, i, crc32ChecksumLast, true), array);
        gcode.Add(array);
        return gcode;
    }
    
    public static string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return char.ToUpper(input[0]) + input.Substring(1);
    }
    
    public static double GramsUsed(double meters, GCodeMeta gCodeMeta)
    {
        return FilamentMetersToGrams(meters, gCodeMeta.FilamentDiameter, gCodeMeta.FilamentDensity);
    }
    
    private static double FilamentMetersToGrams(double meters, double filamentDiameter, double filamentDensity)
    {
        var volume = Math.PI * Math.Pow(filamentDiameter / 2, 2) * meters * 100;
        var weight = volume * filamentDensity;
        //return Math.Round(weight, 2);
        return weight;
    }
    
    }
}