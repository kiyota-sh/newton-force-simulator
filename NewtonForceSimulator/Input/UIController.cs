using Raylib_cs;

namespace NewtonForceSimulator.Input;

public sealed class UIController
{
        public void Update(
        SimulationSettings settings)
    {
        HandleMass(settings);

        HandleForce(settings);

        HandleAngle(settings);

        HandleMuK(settings);

        HandlePause(settings);

        HandleReset(settings);
    }

    private void HandleMass(
        SimulationSettings settings)
    {
        if (Raylib.IsKeyDown(KeyboardKey.Up))
        {
            settings.Mass += 0.1f;
        }

        if (Raylib.IsKeyDown(KeyboardKey.Down))
        {
            settings.Mass -= 0.1f;
        }

        settings.Mass =
            Validation.ClampMass(settings.Mass);
    }

    private void HandleForce(
        SimulationSettings settings)
    {
        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            settings.AppliedForce += 1f;
        }

        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            settings.AppliedForce -= 1f;
        }

        settings.AppliedForce =
            Validation.ClampForce(
                settings.AppliedForce);
    }

    private void HandleAngle(
        SimulationSettings settings)
    {
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            settings.AngleDegrees -= 0.5f;
        }

        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            settings.AngleDegrees += 0.5f;
        }

        settings.AngleDegrees =
            Validation.ClampAngle(
                settings.AngleDegrees);
    }

    private void HandleMuK(
        SimulationSettings settings)
    {
        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            settings.MuK += 0.01f;
        }

        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            settings.MuK -= 0.01f;
        }

        settings.MuK =
            Validation.ClampMuK(
                settings.MuK);
    }
    
    private void HandleForceAngle(
        SimulationSettings settings)
    {
        if (Raylib.IsKeyDown(KeyboardKey.Q))
        {
            settings.AppliedForceAngle -= 1f;
        }

        if (Raylib.IsKeyDown(KeyboardKey.E))
        {
            settings.AppliedForceAngle += 1f;
        }

        if (settings.AppliedForceAngle < 0)
        {
            settings.AppliedForceAngle += 360f;
        }

        if (settings.AppliedForceAngle >= 360f)
        {
            settings.AppliedForceAngle -= 360f;
        }
    }

    private void HandlePause(
        SimulationSettings settings)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            settings.IsPaused =
                !settings.IsPaused;
        }
    }

    private void HandleReset(
        SimulationSettings settings)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.R))
        {
            settings.Reset();
        }
    }
}