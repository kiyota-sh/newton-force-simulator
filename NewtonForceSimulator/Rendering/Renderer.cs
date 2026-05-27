using Raylib_cs;

namespace NewtonForceSimulator.Rendering;

public class Renderer
{
    public void Draw()
    {
        DrawFPS();
    }

    private void DrawFPS()
    {
        Raylib.DrawFPS(10, 10);
    }
}