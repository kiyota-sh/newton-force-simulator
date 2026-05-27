using NewtonForceSimulator.Input;
using NewtonForceSimulator.Physics;
using Raylib_cs;

namespace NewtonForceSimulator.Rendering;

public sealed class UIRenderer
{
        public void Draw(
        SimulationSettings settings,
        Engine physics)
    {
        DrawPanel();

        DrawSimulationValues(settings);

        DrawPhysicsResults(physics);

        DrawQuadrant(settings.AngleDegrees);
    }

    private void DrawPanel()
    {
        Raylib.DrawRectangle(
            980,
            0,
            300,
            720,
            Color.LightGray);
    }

    private void DrawSimulationValues(
        SimulationSettings settings)
    {
        Raylib.DrawText(
            $"Mass: {settings.Mass:F1} kg",
            1000,
            50,
            20,
            Color.Black);

        Raylib.DrawText(
            $"Force: {settings.AppliedForce:F1} N",
            1000,
            90,
            20,
            Color.Black);

        Raylib.DrawText(
            $"Angle: {settings.AngleDegrees:F1}°",
            1000,
            130,
            20,
            Color.Black);

        Raylib.DrawText(
            $"μk: {settings.MuK:F2}",
            1000,
            170,
            20,
            Color.Black);
        
        Raylib.DrawText(
            $"Force Angle: {settings.AppliedForceAngle:F1}°",
            1000,
            210,
            20,
            Color.Purple);
    }

    private void DrawPhysicsResults(
        Engine physics)
    {
        Raylib.DrawText(
            $"Normal: {physics.CurrentNormal:F2} N",
            1000,
            260,
            20,
            Color.DarkGreen);

        Raylib.DrawText(
            $"Friction: {physics.CurrentFriction:F2} N",
            1000,
            300,
            20,
            Color.Maroon);

        Raylib.DrawText(
            $"Acceleration: {physics.CurrentAcceleration:F2} m/s²",
            1000,
            340,
            20,
            Color.Blue);
    }

    private void DrawQuadrant(float angle)
    {
        string quadrant = GetQuadrant(angle);

        Raylib.DrawText(
            $"Quadrant: {quadrant}",
            1000,
            420,
            24,
            Color.Purple);
    }

    private string GetQuadrant(float angle)
    {
        angle %= 360f;

        if (angle >= 0 && angle < 90)
            return "I";

        if (angle >= 90 && angle < 180)
            return "II";

        if (angle >= 180 && angle < 270)
            return "III";

        return "IV";
    }
}