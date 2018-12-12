using System;
using OpenTK;
using System.Collections.Generic;
using System.Linq;

namespace MoveOnGrid
{
    class Model
    {
        public IEnumerable<GameObject> GameObjects => _gameObjects;

        public Vector2 WorldSize { get; private set; }

        private readonly List<GameObject> _gameObjects;
        private World _world;

        private Walker _walker;

        public Model()
        {
            WorldSize = new Vector2(50, 50);
            _gameObjects = new List<GameObject>();
            _world = new World(ref _gameObjects);
            _walker = new Walker(_world);
            _gameObjects.Add(_walker);
        }

        public void Update(float deltaTime)
        {

        }
    }
}
