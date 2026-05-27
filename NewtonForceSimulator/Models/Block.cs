using System.Numerics;

namespace NewtonForceSimulator.Models;

public sealed class Block
{
    public float Mass { get; set; }
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public Vector2 Acceleration { get; set; }
    public float Size { get; }
    
    public float DistanceAlongPlane { get; set; }

    public Block(
        float mass,
        Vector2 position,
        float size)
    {
        Mass = mass;
        Position = position;
        Size = size;
        
        Velocity = Vector2.Zero;
        Acceleration = Vector2.Zero;
    }

}