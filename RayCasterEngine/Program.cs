namespace RayCasterEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectilePosition = new Point3d(0, 1, 0);
            var projectileVelocity = (Vector3d)(new Vector3d(1, 1, 0)).GetNormalizedTuple3d();
            var projectile = new Projectile(projectilePosition, projectileVelocity);

            var envGravity = new Vector3d(0, -0.1, 0);
            var envWind = new Vector3d(-0.01, 0, 0);
            var env = new RayCasterEngine.Environment(envGravity, envWind);

            var continueLoop = true;
            while (continueLoop)
            {
                projectile = Projectile.Tick(env, projectile);
                System.Console.WriteLine(projectile.GetPosition());
                continueLoop = !(HelperMath.NearlyEqual(projectile.Position.coord.y, 0.0) || projectile.Position.coord.y < 0.0);
            }
        }
    }
}
