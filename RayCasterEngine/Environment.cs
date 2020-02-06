namespace RayCasterEngine
{
    class Environment
    {
        public Tuple<Tuple3d> Gravity { get; }

        public Tuple<Tuple3d> Wind { get; }

        public Environment(Tuple<Tuple3d> gravity, Tuple<Tuple3d> wind)
        {
            Gravity = gravity;
            Wind = wind;
        }
    }
}
