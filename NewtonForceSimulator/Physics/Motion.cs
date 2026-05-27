using System.Numerics;
using NewtonForceSimulator.Models;

namespace NewtonForceSimulator.Physics;

public sealed class Motion
{
    public void Integrate(
        Block block,
        Vector2 acceleration,
        float deltaTime)
    {
        block.Acceleration = acceleration;

        block.Velocity +=
            block.Acceleration * deltaTime;

        block.Position +=
            block.Velocity * deltaTime;
    }
}