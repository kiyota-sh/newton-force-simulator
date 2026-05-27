using System.Numerics;
using NewtonForceSimulator.Models;
using Raylib_cs;

namespace NewtonForceSimulator.Rendering;

public class Renderer
{
    private readonly InclinedPlane _plane;
    private readonly Block _block;
    private readonly DiagramRenderer _diagramRenderer;

    public Renderer()
    {
        _plane = new InclinedPlane(
            new Vector2(250, 500),
            new Vector2(950, 250),
            30f);

        _block = new Block(
            5f,
            new Vector2(500, 400),
            100f);

        _diagramRenderer = new();
    }
    
    public void Draw()
    {
        DrawInclinedPlane();
        DrawBlockAndVectors();
        DrawFPS();
    }

    public void DrawBlockAndVectors()
    {
        _diagramRenderer.DrawBlock(
            _block,
            _plane.AngleDegrees);

        Force weight = new(
            "mg",
            new Vector2(0, 1),
            120f,
            Color.White);

        Force normal = new(
            "N",
            new Vector2(-0.5f, -1f),
            120f,
            Color.Green);

        Force applied = new(
            "F",
            new Vector2(1f, -0.5f),
            90f,
            Color.Purple);

        _diagramRenderer.DrawForce(
            _block,
            weight,
            1f);
        _diagramRenderer.DrawForce(
            _block,
            normal,
            1f);
        _diagramRenderer.DrawForce(
            _block,
            applied,
            1f);
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