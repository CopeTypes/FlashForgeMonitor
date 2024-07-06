using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FlashForgeMonitor.api.util
{
    // parse g-code slicer metadata for useful info
    public class GCodeMeta
    {
     
        // these values were extracted from a file sliced by orca slicer
        // todo support for other slicers
        private const string printingTimePattern = @"estimated printing time \(normal mode\) = ([\d\sm]+)";
        private const string filamentUsedPattern = @"total filament used \[g\] = ([\d\.]+)";
        private const string filamentDensityPattern = @"filament_density: ([\d\.]+)";
        private const string filamentDiameterPattern = @"filament_diameter: ([\d\.]+)";

        private string gcodeData;
        
        public string FileName { get; }
        public string PrintEta { get; }
        public string TotalFilamentUsed { get; }
        public double FilamentDensity { get; }
        public double FilamentDiameter { get; }

        public GCodeMeta(string filePath)
        {
            if (!File.Exists(filePath)) throw new Exception($"GCodeParser error, input file path {filePath} does not exist");
            gcodeData = File.ReadAllText(filePath);
            FileName = Path.GetFileName(filePath);
            
            var printingTimeMatch = Regex.Match(gcodeData, printingTimePattern);
            if (printingTimeMatch.Success) PrintEta = printingTimeMatch.Groups[1].Value;
            
            var filamentUsedMatch = Regex.Match(gcodeData, filamentUsedPattern);
            if (filamentUsedMatch.Success) TotalFilamentUsed = filamentUsedMatch.Groups[1].Value;
            
            var filamentDensityMatch = Regex.Match(gcodeData, filamentDensityPattern);
            if (filamentDensityMatch.Success) FilamentDensity = double.Parse(filamentDensityMatch.Groups[1].Value);
            
            var filamentDiameterMatch = Regex.Match(gcodeData, filamentDiameterPattern);
            if (filamentDiameterMatch.Success) FilamentDiameter = double.Parse(filamentDiameterMatch.Groups[1].Value);
        }
    }
}