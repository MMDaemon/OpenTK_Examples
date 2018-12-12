using System;
using OpenTK;
using System.Collections.Generic;
using System.Linq;

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
        private Random _rand = new Random();

        public Model()
        {
            WorldSize = new Vector2(50, 50);
            _gameObjects = new List<GameObject>();
            _world = new GameObject[(int)WorldSize.X, (int)WorldSize.Y];

            InitiateWorld();
        }

        public void Update(float deltaTime)
        {

        }

        private void InitiateWorld()
        {
            for (int x = 0; x < WorldSize.X; x++)
            {
                for (int y = 0; y < WorldSize.Y; y++)
                {
                    _world[x, y] = new GameObject(0, new Vector2(x, y), new Vector2(1, 1));
                    _gameObjects.Add(_world[x, y]);
                }
            }

            CreatePath();
        }

        private void ClearWorld()
        {
            for (int x = 0; x < WorldSize.X; x++)
            {
                for (int y = 0; y < WorldSize.Y; y++)
                {
                    if (_world[x, y].Type != 0)
                    {
                        SetType(new Vector2(x, y), 0);
                    }
                }
            }
        }

        private void CreatePath()
        {
            Vector2 pos = new Vector2(_rand.Next(0, (int)WorldSize.X), 0);

            SetType(pos, 1);

            while (pos.Y < WorldSize.Y - 1)
            {
                pos = Step(pos);
                if (pos == -Vector2.One)
                {
                    ClearWorld();
                    CreatePath();
                    break;
                }
                else
                {
                    SetType(pos, 1);
                }
            }
        }

        private Vector2 Step(Vector2 position)
        {
            List<Vector2> neighbors = GetNeighborPositions(position).ToList();

            foreach (Vector2 neighbor in neighbors.ToArray())
            {
                if (_world[(int)neighbor.X, (int)neighbor.Y].Type == 1)
                {
                    neighbors.Remove(neighbor);
                }
                else
                {
                    IEnumerable<Vector2> nextNeighbors = GetNeighborPositions(neighbor);
                    foreach (Vector2 nextNeighbor in nextNeighbors)
                    {
                        if (nextNeighbor != position && _world[(int)nextNeighbor.X, (int)nextNeighbor.Y].Type == 1)
                        {
                            neighbors.Remove(neighbor);
                        }
                    }
                }
            }

            return neighbors.Count > 0 ? neighbors[_rand.Next(0, neighbors.Count)] : -Vector2.One;
        }

        private IEnumerable<Vector2> GetNeighborPositions(Vector2 pos)
        {
            List<Vector2> neighbors = new List<Vector2>();
            if (pos.X + 1 < WorldSize.X)
            {
                neighbors.Add(pos + Vector2.UnitX);
            }
            if (pos.X - 1 >= 0)
            {
                neighbors.Add(pos - Vector2.UnitX);
            }
            if (pos.Y + 1 < WorldSize.Y)
            {
                neighbors.Add(pos + Vector2.UnitY);
            }
            if (pos.Y - 1 >= 0)
            {
                neighbors.Add(pos - Vector2.UnitY);
            }
            return neighbors;
        }

        private void SetType(Vector2 pos, int type)
        {
            _gameObjects.Remove(_world[(int)pos.X, (int)pos.Y]);
            _world[(int)pos.X, (int)pos.Y] = new GameObject(type, pos, new Vector2(1));
            _gameObjects.Add(_world[(int)pos.X, (int)pos.Y]);
        }
    }
}
