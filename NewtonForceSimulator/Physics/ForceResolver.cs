using System.Numerics;

namespace NewtonForceSimulator.Physics;

public sealed class ForceResolver
{
    public Vector2 ResolveForce(
        float magnitude,
        float angleDegrees)
    {
        float radians =
            MathF.PI / 180f * angleDegrees;

        return new Vector2(
            magnitude * MathF.Cos(radians),
            magnitude * MathF.Sin(radians));
    }
}