using NewtonForceSimulator.Core;

namespace NewtonForceSimulator.Physics;

public sealed class Calculator
{
    public float CalculateWeight(float mass)
    {
        return mass * Constants.Gravity;
    }

    public float CalculateParallelForce(
        float mass,
        float angleRadians)
    {
        return CalculateWeight(mass)
               * MathF.Sin(angleRadians);
    }

    public float CalculateNormalForce(
        float mass,
        float angleRadians)
    {
        return CalculateWeight(mass)
               * MathF.Cos(angleRadians);
    }

    public float CalculateNetForce(
        float appliedForce,
        float frictionForce,
        float parallelForce)
    {
        return appliedForce
               - frictionForce
               - parallelForce;
    }

    public float CalculateAcceleration(
        float netForce,
        float mass)
    {
        return netForce / mass;
    }
    
    public float CalculateKineticFriction(
        float muK,
        float normalForce)
    {
        return muK * normalForce;
    }
}