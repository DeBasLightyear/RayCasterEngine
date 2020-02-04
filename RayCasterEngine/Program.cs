using System;

namespace RayCasterEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectilePosition = Tuple3d.Point(0, 1, 0);
            var projectileVelocity = Tuple3d.Normalize(Tuple3d.Vector(1, 1, 0));
            var projectile = new Projectile(projectilePosition, projectileVelocity);

            var envGravity = Tuple3d.Vector(0, -0.1, 0);
            var envWind = Tuple3d.Vector(-0.01, 0, 0);
            var env = new RayCasterEngine.Environment(envGravity, envWind);

            var continueLoop = true;
            while (continueLoop)
            {
                projectile = Projectile.Tick(env, projectile);
                System.Console.WriteLine(projectile.GetPosition());
                continueLoop = !(HelperMath.NearlyEqual(projectile.Position.Y, 0.0) || projectile.Position.Y < 0.0);
            }
        }
    }
}
