using OpenTK;

namespace MoveOnGrid
{
    class Controller
    {

        static void Main(string[] args)
        {
            GameWindow window = new GameWindow();
            Model model = new Model();
            View view = new View();

            window.UpdateFrame += (s, e) => model.Update((float)e.Time);
            window.Resize += (s, e) => view.Resize(window.Width, window.Height);
            window.RenderFrame += (s, e) => view.Render(model.GameObjects, model.WorldSize);
            window.RenderFrame += (s, e) => window.SwapBuffers();

            window.Run();
        }
    }
}
