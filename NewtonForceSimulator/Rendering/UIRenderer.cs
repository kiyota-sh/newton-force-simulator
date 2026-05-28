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

        DrawQuadrant(physics.CurrentQuadrant);
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
            $"Mass: {settings.Mass:F0} kg",
            1000,
            50,
            20,
            Color.Black);

        Raylib.DrawText(
            $"Force: {settings.AppliedForce:F0} N",
            1000,
            90,
            20,
            Color.Black);

        Raylib.DrawText(
            $"Angle: {settings.AngleDegrees:F0}°",
            1000,
            130,
            20,
            Color.Black);

        Raylib.DrawText(
            $"Uk: {settings.MuK:F1}",
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

    private void DrawQuadrant(Quadrant quadrant)
    {
        Raylib.DrawText(
            $"Quadrant: {(int)quadrant}",
            1000,
            420,
            24,
            Color.Purple);
    }
}