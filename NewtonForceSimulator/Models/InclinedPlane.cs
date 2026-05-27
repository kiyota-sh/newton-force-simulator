using System.Numerics;

namespace NewtonForceSimulator.Models;

public class InclinedPlane
{
    public Vector2 Start { get; }
    public Vector2 End { get; }
    public float AngleDegrees { get; }

    public InclinedPlane(
        Vector2 start,
        Vector2 end,
        float angleDegrees)
    {
        Start = start;
        End = end;
        AngleDegrees = angleDegrees;
    }
}