using System;
using System.Linq;

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
            
        }

        private static string GetHeader(Canvas canvas)
        {
            return $"P3\n{canvas.Width} {canvas.Height}\n{MaxColorValue}\n";
        }

        private static string GetPixelString(Canvas canvas)
        {
            // Scale to MaxColorValue
            // Clamp to 0 where < 0 and 255 where > 255
            // Convert each row to one string (join with \s)
            // Truncate each row string on previous \s where row length > 70 (replace \s with \n)
            // Join all row strings to one large string with \n

        }

        private static string ConvertPixelGrid(Canvas canvas)
        {
            // Convert each row of Color objects into one PPM-formatted color string
            var rowStrings = ConvertColors(canvas);

            // Truncate rows to a maximum of 70 characters
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
                colorStrings.Append(cRow);
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
                                            return (int)el;
                                        }).ToArray();

            // Convert to color string
            return $"{clampedColors[0]} {clampedColors[1]} {clampedColors[2]} ";
        }

        // private static string GetPixelData(Canvas canvas)
        // {
        //     var result = "";
        //     foreach(var color in canvas.PixelGrid)
        //     {
        //         result += ConvertColor(color);
        //     }

        //     return result;
        // }

        // private static string ConvertColor(Color color)
        // {
        //     var scalar = 255;
        //     var clampedColors = (color * scalar).Data.Select( el =>
        //     {
        //         if (el < 0)
        //             return 0;
        //         if (el > scalar)
        //             return scalar;
        //         return (int)el;
        //     }).ToArray();

        //     return $"{clampedColors[0]} {clampedColors[1]} {clampedColors[2]}";
        // }
    }
}