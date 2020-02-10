using System;
using System.Linq;

namespace RayCasterEngine
{
    class Program
    {
        static void Main(string[] args)
        {   
            // Canvas
            var canvas = new Canvas(640, 480);
            
            // Projectile
            var start = Tuple3d.Point(0, 1, 0);
            var velocity = Tuple3d.Normalize(Tuple3d.Vector(1.0, 1.8, 0.0)) * 9.25;
            var projectile = new Projectile(start, velocity);
            
            // Environment
            var gravity = Tuple3d.Vector(0, -0.1, 0);
            var wind = Tuple3d.Vector(-0.01, 0, 0);
            var env = new Environment(gravity, wind);

            // Ticks
            while (projectile.Position.Y >= 0)
            {
                // Perform the tick
                projectile = Projectile.Tick(env, projectile);
                System.Console.WriteLine(projectile.GetPosition());

                // Write it to canvas
                var X = (int)Math.Round(projectile.Position.X);
                var Y = (int)Math.Round(canvas.Height - projectile.Position.Y);
                canvas.WritePixel(X, Y, new Color(0.60,0.50,0.00));
            }

            // Write file when the projectile has crashed
            var fileDest = "C:/Users/Bas/Desktop";
            var fileName = "projectilePath";
            var ppmString = PortablePixmapWriter.CanvasToPPM(canvas);
            PortablePixmapWriter.WritePpmFile(ppmString, fileName, fileDest);
        }
    }
}
