using System.Numerics;
using NewtonForceSimulator.Models;

namespace NewtonForceSimulator.Physics;

public sealed class Motion
{
    private readonly PlaneCoordinateSystem _planeSystem;

    public Motion()
    {
        _planeSystem = new PlaneCoordinateSystem();
    }

    public void Integrate(
        Block block,
        InclinedPlane plane,
        float acceleration,
        float deltaTime)
    {
        Vector2 accelerationVector =
            plane.Direction * acceleration;

        block.Acceleration =
            accelerationVector;

        block.Velocity +=
            block.Acceleration * deltaTime;

        block.DistanceAlongPlane +=
            block.Velocity.Length() * deltaTime;

        block.Position =
            _planeSystem.GetPositionOnPlane(
                plane,
                block.DistanceAlongPlane);
        
        if (block.DistanceAlongPlane >= plane.Length)
        {
            block.DistanceAlongPlane =
                plane.Length;

            block.Velocity = Vector2.Zero;
        }
    }
}