namespace NewtonForceSimulator.Physics;

public sealed class QuadrantResolver
{
    public Quadrant Resolve(float angle)
    {
        angle %= 360f;

        if (angle < 0)
        {
            angle += 360f;
        }

        if (angle >= 0 && angle <= 90)
        {
            return Quadrant.First;
        }

        if (angle >= 90 && angle <= 180)
        {
            return Quadrant.Second;
        }

        if (angle >= 180 && angle <= 270)
        {
            return Quadrant.Third;
        }

        return Quadrant.Fourth;
    }
}