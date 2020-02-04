namespace RayCasterEngine
{
    class Projectile
    {
        public Point3d Position { get; }

        public Vector3d Velocity { get; }

        public Projectile(Point3d position, Vector3d velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public static Projectile Tick(Environment env, Projectile proj)
        {
            var position = (Point3d)(proj.Position + proj.Velocity);
            var velocity = (Vector3d)(proj.Velocity + env.Gravity + env.Wind);
            return new Projectile(position, velocity);
        }

        public string GetPosition()
        {
            return Position.ToString();
        }
    }
}
