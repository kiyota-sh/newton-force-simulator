using System.Numerics;
using NewtonForceSimulator.Models;

namespace NewtonForceSimulator.Physics;

public sealed class PlaneCoordinateSystem
{
    public Vector2 GetPositionOnPlane(
        InclinedPlane plane,
        float distance)
    {
        return plane.Start
               + plane.Direction * distance;
    }
}