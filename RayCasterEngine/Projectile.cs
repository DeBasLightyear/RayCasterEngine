namespace RayCasterEngine
{
    class Projectile
    {
        public Tuple3d Position { get; }

        public Tuple3d Velocity { get; }

        public Projectile(Tuple3d position, Tuple3d velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public static Projectile Tick(Environment env, Projectile proj)
        {
            var position = proj.Position + proj.Velocity;
            var velocity = proj.Velocity + env.Gravity + env.Wind;
            return new Projectile(position, velocity);
        }

        public string GetPosition()
        {
            return Position.ToString();
        }
    }
}
