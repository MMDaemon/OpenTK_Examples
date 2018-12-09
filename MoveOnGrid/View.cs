using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Collections.Generic;

namespace MoveOnGrid
{
    class View
    {
        float _aspect;

        public void Render(IEnumerable<GameObject> gameObjects, Vector2 worldSize)
        {
            Matrix4 cameraTransformation = Matrix4.CreateScale(new Vector3(2 / worldSize.X, 2 / worldSize.Y, 1)) * Matrix4.CreateTranslation(new Vector3(-1, -1, 0)) * Matrix4.CreateScale(new Vector3(_aspect, 1, 1));

            GL.Clear(ClearBufferMask.ColorBufferBit);

            foreach (var gameObject in gameObjects)
            {
                switch (gameObject.Type)
                {
                    case 0:
                        GL.Color4(Color.Green);
                        break;
                    case 1:
                        GL.Color4(Color.Gray);
                        break;
                    case 2:
                        GL.Color4(Color.Red);
                        break;
                }
                DrawRectangle(gameObject.Bounds, cameraTransformation);
            }
        }

        public void Resize(int width, int height)
        {
            _aspect = (float)height / width;
            GL.Viewport(0, 0, width, height);
        }

        private void DrawRectangle(Rectangle rectangle, Matrix4 cameraTransformation)
        {
            Matrix4 translation = Matrix4.CreateTranslation(new Vector3(rectangle.Position.X, rectangle.Position.Y, 0f));
            Matrix4 scale = Matrix4.CreateScale(new Vector3(rectangle.Size.X, rectangle.Size.Y, 1));
            Matrix4 transformation = translation * scale * cameraTransformation;
            GL.LoadMatrix(ref transformation);

            //draw a quad
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(0.0f, 0.0f); //draw first quad corner
            GL.Vertex2(1.0f, 0.0f);
            GL.Vertex2(1.0f, 1.0f);
            GL.Vertex2(0.0f, 1.0f);
            GL.End();
        }
    }
}
