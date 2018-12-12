using OpenTK;

namespace MoveOnGrid
{
    internal class Walker : GameObject
    {
        public bool Finished { get; private set; }
        private World _world;
        private Vector2 _lastWorldPos;
        private Vector2 _currentWorldPos;

        public Walker(World world) : base(2, Vector2.Zero, new Vector2(0.5f))
        {
            _world = world;
            Bounds.CenterPosition = _world.StartPosition;
            Finished = false;
        }

        public void Update(float deltaTime)
        {
            Vector2 currentWorldPos = CalcWorldPos(Bounds.CenterPosition);
            if (currentWorldPos != _currentWorldPos)
            {
                _lastWorldPos = _currentWorldPos;
                _currentWorldPos = currentWorldPos;
            }

            Vector2 targetPos = -Vector2.One;

            if (_currentWorldPos.Y == _world.Size.Y)
            {
                Finish();
            }
            else if (_currentWorldPos.Y == _world.Size.Y - 1)
            {
                targetPos = new Vector2(_world.GetCenter(_currentWorldPos).X, _world.Size.Y);
            }
            else
            {
                foreach (Vector2 neighbor in _world.GetNeighborPositions(_currentWorldPos))
                {
                    if (neighbor != _lastWorldPos && _world.IsWalkable(neighbor))
                    {
                        targetPos = _world.GetCenter(neighbor);
                    }
                }
            }

            if (targetPos != -Vector2.One)
            {
                Bounds.CenterPosition += Vector2.Normalize(targetPos - Bounds.CenterPosition) * deltaTime * 3;
            }

        }

        private Vector2 CalcWorldPos(Vector2 absolutePos)
        {
            return new Vector2((int)absolutePos.X, (int)absolutePos.Y);
        }

        private void Finish()
        {
            Finished = true;
        }
    }
}
