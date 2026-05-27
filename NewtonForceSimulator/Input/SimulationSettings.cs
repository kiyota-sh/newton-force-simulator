namespace NewtonForceSimulator.Input;

public sealed class SimulationSettings
{
    public float Mass { get; set; } = 5f;

    public float AppliedForce { get; set; } = 120f;

    public float AngleDegrees { get; set; } = 30f;

    public float MuK { get; set; } = 0.2f;

    public float AppliedForceAngle { get; set; } = 45f;

    public bool IsPaused { get; set; }

    public void Reset()
    {
        Mass = 5f;

        AppliedForce = 120f;

        AngleDegrees = 30f;

        MuK = 0.2f;
        
        AppliedForceAngle = 45f;

        IsPaused = false;
    }
}