using System.Numerics;
using NewtonForceSimulator.Models;
using Raylib_cs;

namespace NewtonForceSimulator.Rendering;

public class Renderer
{
    private readonly InclinedPlane _plane;

    public Renderer()
    {
        _plane = new InclinedPlane(
            new Vector2(250, 500),
            new Vector2(950, 250),
            30f);
    }
    
    public void Draw()
    {
        DrawInclinedPlane();
        DrawFPS();
    }

    private void DrawFPS()
    {
        Raylib.DrawFPS(10, 10);
    }

    private void DrawInclinedPlane()
    {
        Raylib.DrawLineEx(
            _plane.Start,
            _plane.End,
            6f,
            new Color(0, 100, 255));
    }
}