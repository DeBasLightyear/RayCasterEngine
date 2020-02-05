using System;

namespace RayCasterEngine
{
    class Projectile
    {
        public Tuple<Point> Position { get; }

        public Tuple<Vector> Velocity { get; }

        public Projectile(Tuple<Point> position, Tuple<Vector> velocity)
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
