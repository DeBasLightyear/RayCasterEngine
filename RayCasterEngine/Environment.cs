namespace RayCasterEngine
{
    class Environment
    {
        public Tuple<Vector> Gravity { get; }

        public Tuple<Vector> Wind { get; }

        public Environment(Tuple<Vector> gravity, Tuple<Vector> wind)
        {
            Gravity = gravity;
            Wind = wind;
        }
    }
}
