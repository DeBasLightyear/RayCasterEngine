using System;
using System.Linq;
using System.Collections.Generic;

namespace RayCasterEngine
{
    public static class PortablePixmapWriter
    {
        private static readonly int MaxColorValue;
        
        static PortablePixmapWriter()
        {
            MaxColorValue = 255;
        }

        public static string CanvasToPPM(Canvas canvas)
        {
            // First get header
            var header = GetHeader(canvas);

            // Then get pixelstring
            var pixelstring = GetPixelString(canvas);

            // Put them together with extra \n at the end
            return header + pixelstring + "\n";
        }

        public static void WritePpmFile(string ppmString, string fileName, string destination)
        {
            var filePath = $"{destination}/{fileName}.ppm";
            System.IO.File.WriteAllText(filePath, ppmString);
        }

        private static string GetHeader(Canvas canvas)
        {
            return $"P3\n{canvas.Width} {canvas.Height}\n{MaxColorValue}\n";
        }

        private static string GetPixelString(Canvas canvas)
        {
            // Convert the color for each pixel to PPM-format
            var pixelsPPM = ConvertColors(canvas);

            // Truncate each row string on previous \s where row length > 70 (replace \s with \n)
            var truncPixelsPPM = TruncatePixelStrings(pixelsPPM);
            
            // Join all row strings to one large string with \n
            return String.Join("\n", truncPixelsPPM);
        }

        private static string[] ConvertColors(Canvas canvas)
        {
            // Convert each color in a row into a PPM color string
            var colorStrings = new string[canvas.Height];
            for (var i = 0; i < canvas.Height; i++)
            {
                var cRow = "";
                for (var j = 0; j < canvas.Width; j++)
                {
                    // Make one string for each row
                    cRow +=  ConvertColor(canvas.PixelGrid[i, j]);
                }
                // Add row to array
                colorStrings[i] = cRow.Substring(0, cRow.Length - 1); // remove the last space for each row
            }
            
            return colorStrings;
        }

        private static string ConvertColor(Color color)
        {
            var clampedColors = (color * MaxColorValue)      // scale to maximal color value
                                        .Data.Select( el =>  // clamp the value to make it fit into the range of 0 - 255
                                        {
                                            if (el < 0)
                                                return 0;
                                            if (el > MaxColorValue)
                                                return MaxColorValue;    
                                            return Math.Ceiling(el);
                                        }).ToArray();

            // Convert to color string
            return $"{clampedColors[0]} {clampedColors[1]} {clampedColors[2]} ";
        }

        private static string TruncatePixelStrings(string[] toTrunc)
        {
            // Where row is longer than 70 characters
            // Find the last space before the 70th character
            // Else add unaltered row to result
            
            var truncRows = new List<string>();
            for(var i = 0; i < toTrunc.Length; i++)
            {
                var cRow = toTrunc[i];
                truncRows.AddRange(SplitPixelString(cRow));
            }
            return String.Join("\n", truncRows);
        }

        private static List<string> SplitPixelString(string pixelString)
        {
            // Lines in a PPM-file should be no longer than 70 chars. Split on last space before 70th char if longer
            var truncStrings = new List<string>();
            var cString = pixelString;
            var amountSubstrings = Math.Ceiling((double)(pixelString.Length / 70));

            var i = 0;
            do
            {
                // Determine how far we need to go on this iteration
                var cLength = cString.Length;
                var cEnd = cLength > 70 ? 70 : cLength;

                // Take the first piece when the string is longer than 70 characters
                var idx = cString.Substring(0, cEnd).LastIndexOf(" ");
                truncStrings.Add(
                    cLength > 70
                    ? cString.Substring(0, idx)
                    : cString
                );

                // Remove the part that was truncated. Don't remove anything if the string is shorter than 71 characters
                cString = cString.Substring(idx + 1);
                i++;
            }
            while (i <= amountSubstrings);

            return truncStrings;
        }
    }
}