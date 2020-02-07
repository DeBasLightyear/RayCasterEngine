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
            PixelGrid[y, x] = color;
        }
        public Color GetPixel(int x, int y)
        {
            return PixelGrid[y, x];
        }
    }
}