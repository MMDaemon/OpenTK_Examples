using OpenTK;
using System.Collections.Generic;

namespace MoveOnGrid
{
    class Model
    {
        public IEnumerable<GameObject> GameObjects
        {
            get => _gameObjects;
        }

        public Vector2 WorldSize { get; private set; }

        private List<GameObject> _gameObjects;

        private GameObject[,] _world;

        public Model()
        {
            WorldSize = new Vector2(50, 50);
            _gameObjects = new List<GameObject>();
            _world = new GameObject[(int)WorldSize.X, (int)WorldSize.Y];

            for (int x = 0; x < WorldSize.X; x++)
            {
                for (int y = 0; y < WorldSize.Y; y++)
                {
                    _world[x, y] = new GameObject(0, new Vector2(x, y), new Vector2(1, 1));
                    _gameObjects.Add(_world[x, y]);
                }
            }
        }

        public void Update(float deltaTime)
        {

        }
    }
}
