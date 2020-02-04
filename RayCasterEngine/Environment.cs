namespace RayCasterEngine
{
    class Environment
    {
        public Tuple3d Gravity { get; }

        public Tuple3d Wind { get; }

        public Environment(Tuple3d gravity, Tuple3d wind)
        {
            Gravity = gravity;
            Wind = wind;
        }
    }
}
