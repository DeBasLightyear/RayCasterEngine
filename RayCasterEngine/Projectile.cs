using System;

namespace RayCasterEngine
{
    class Projectile
    {
        public Tuple<Tuple3d> Position { get; }

        public Tuple<Tuple3d> Velocity { get; }

        public Projectile(Tuple<Tuple3d> position, Tuple<Tuple3d> velocity)
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
