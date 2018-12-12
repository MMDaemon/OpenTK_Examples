using OpenTK;

namespace MoveOnGrid
{
    internal class Walker : GameObject
    {
        private World _world;

        public Walker(World world) : base(2, Vector2.Zero, new Vector2(0.5f))
        {
            _world = world;
            Bounds.CenterPosition = _world.StartPosition;
        }

        public void Update(float deltaTime)
        {

        }
    }
}
