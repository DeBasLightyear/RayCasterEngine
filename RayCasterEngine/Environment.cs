namespace RayCasterEngine
{
    class Environment
    {
        public Vector3d Gravity { get; }

        public Vector3d Wind { get; }

        public Environment(Vector3d gravity, Vector3d wind)
        {
            Gravity = gravity;
            Wind = wind;
        }
    }
}
