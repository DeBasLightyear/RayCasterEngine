using System;
using System.Linq;

namespace RayCasterEngine
{
    class Program
    {
        static void Main(string[] args)
        {   
            // var projectilePosition = Tuple3d.Point(0, 1, 0);
            // var projectileVelocity = RayCasterEngine.Tuple3d.Normalize(Tuple3d.Vector(1, 1, 0));
            // var projectile = new Projectile(projectilePosition, projectileVelocity);

            // var envGravity = Tuple3d.Vector(0, -0.1, 0);
            // var envWind = Tuple3d.Vector(-0.01, 0, 0);
            // var env = new Environment(envGravity, envWind);

            // while (projectile.Position.Y >= 0)
            // {
            //     projectile = Projectile.Tick(env, projectile);
            //     System.Console.WriteLine(projectile.GetPosition());
            // }

            var canvas = new Canvas(5, 3);
            var ppm = PortablePixmapWriter.CanvasToPPM(canvas);
            System.Console.WriteLine(ppm);
        }
    }
}
