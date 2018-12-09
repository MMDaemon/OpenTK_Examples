using OpenTK;

namespace MoveOnGrid
{
    public class GameObject
    {
        public Rectangle Bounds;
        public int Type { get; private set; }

        public GameObject(int type, Vector2 position, Vector2 size)
        {
            Type = type;
            Bounds = new Rectangle(position, size);
        }

        public void Update(float deltaTime)
        {

        }
    }
}
