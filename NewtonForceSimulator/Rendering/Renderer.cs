using System.Numerics;
using NewtonForceSimulator.Input;
using NewtonForceSimulator.Models;
using NewtonForceSimulator.Physics;
using Raylib_cs;

namespace NewtonForceSimulator.Rendering;

public class Renderer
{
    private readonly InclinedPlane _plane;
    private readonly Block _block;
    private readonly DiagramRenderer _diagramRenderer;
    private readonly Engine _engine;

    private float _appliedForce = 120f;
    private float _uk = 0.1f;
    
    private readonly SimulationSettings _settings;
    private readonly UIRenderer _uiRenderer;

    public Renderer(SimulationSettings settings)
    {
        _settings = settings;
        
        _plane = new InclinedPlane(
            new Vector2(250, 500),
            new Vector2(950, 250),
            30f);

        _block = new Block(
            5f,
            new Vector2(500, 400),
            100f);

        _diagramRenderer = new();
        _engine = new ();
        
        _uiRenderer = new UIRenderer();
    }

    public void Update(float deltaTime)
    {
        _block.Mass = _settings.Mass;

        if (!_settings.IsPaused)
        {
            _engine.Update(
                _block,
                _plane,
                _settings.AppliedForce,
                _settings.AppliedForceAngle,
                _plane.AngleDegrees,
                _settings.MuK,
                deltaTime);
        }
    }
    
    public void Draw()
    {
        _uiRenderer.Draw(_settings, _engine);
        DrawInclinedPlane();
        DrawBlockAndVectors();
        DrawPhysicsInfo();
        DrawFPS();
    }

    private void DrawPhysicsInfo()
    {
        Raylib.DrawText(
            $"Weigth: {_engine.currentWeight:F2} N",
            20, 40, 20, new Color(0, 255, 244));
        Raylib.DrawText(
            $"Mass: {_block.Mass} KG",
            20, 60, 20, new Color(0, 255, 244));
        Raylib.DrawText(
            $"Normal force: {_engine.CurrentNormal:F2} N",
            20, 80, 20, new Color(0, 255, 244));
        Raylib.DrawText(
            $"Friction: {_engine.CurrentFriction:F2} N",
            20, 100, 20, new Color(0, 255, 244));
        Raylib.DrawText(
            $"Acceleration: {_engine.CurrentAcceleration:F2} m/s^2",
            20, 120, 20, new Color(0, 255, 244));
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