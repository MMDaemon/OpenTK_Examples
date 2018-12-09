using OpenTK;

namespace MoveOnGrid
{
    public class Rectangle
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 CenterPosition
        {
            get => Position + Size * 0.5f;
            set => Position = value - Size * 0.5f;
        }

        public Rectangle(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
        }
    }
}
