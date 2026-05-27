using System.Numerics;
using NewtonForceSimulator.Models;

namespace NewtonForceSimulator.Physics;

public sealed class Engine
{
    private readonly Calculator _calculator;
    private readonly Motion _motion;

    public Engine()
    {
        _calculator = new();
        _motion = new();
    }

    public float currentWeight { get; private set; }
    public float CurrentNormal { get; private set; }
    public float CurrentFriction { get; private set; }
    public float CurrentAcceleration { get; private set; }

    public void Update(
        Block block,
        float appliedForce,
        float angleDegrees,
        float muK,
        float deltaTime)
    {
        float angleRadians =
            MathF.PI / 180f * angleDegrees;

        float parallelForce =
            _calculator.CalculateParallelForce(
                block.Mass,
                angleRadians);
        
        currentWeight =
            _calculator.CalculateWeight(block.Mass);

        CurrentNormal =
            _calculator.CalculateNormalForce(
                block.Mass,
                angleRadians);

        CurrentFriction =
            _calculator.CalculateKineticFriction(
                muK,
                CurrentNormal);

        float netForce =
            _calculator.CalculateNetForce(
                appliedForce,
                CurrentFriction,
                parallelForce);

        CurrentAcceleration =
            _calculator.CalculateAcceleration(
                netForce,
                block.Mass);
        
        Vector2 accelerationVector =
            new(CurrentAcceleration, 0);

        _motion.Integrate(
            block,
            accelerationVector,
            deltaTime);
    }
}