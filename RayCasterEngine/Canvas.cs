using System.Linq;

namespace RayCasterEngine
{
    public class Canvas
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Color[,] PixelGrid { get; }

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            PixelGrid = new Color[Height, Width];
            
            WriteAllPixels(new Color(0, 0, 0));
        }

        public void WriteAllPixels(Color color)
        {
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    PixelGrid[i, j] = color;
                }
            }
        }

        public void WritePixel(int x, int y, Color color)
        {
            if (x > Width - 1 || x < 0 || y > Height - 1 || y < 0) // not on canvas
            {
                // Do nothing...
            }
            else // on canvas
            {
                PixelGrid[y, x] = color; // write pixel
            }
        }
        public Color GetPixel(int x, int y)
        {
            return PixelGrid[y, x];
        }
    }
}