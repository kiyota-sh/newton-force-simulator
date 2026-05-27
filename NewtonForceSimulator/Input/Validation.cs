namespace NewtonForceSimulator.Input;

public static class Validation
{
    public static float ClampMass(float mass)
    {
        return Math.Clamp(mass, 0.1f, 1000f);
    }

    public static float ClampAngle(float angle)
    {
        return Math.Clamp(angle, 1f, 89f);
    }

    public static float ClampMuK(float muK)
    {
        return Math.Clamp(muK, 0f, 1f);
    }

    public static float ClampForce(float force)
    {
        return Math.Clamp(force, -500f, 500f);
    }
}