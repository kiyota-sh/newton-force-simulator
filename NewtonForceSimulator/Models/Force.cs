using System.Numerics;
using Raylib_cs;

namespace NewtonForceSimulator.Models;

public class Force
{
    public String Name { get; }
    public Vector2 Direction { get; }
    public float Magnitude { get; }
    
    public Color Color { get; }

    public Force(
        string name,
        Vector2 direction,
        float magnitude,
        Color color)
    {
        Name = name;
        Direction = direction;
        Magnitude = magnitude;
        Color = color;
    }

    public Vector2 GetVector()
    {
        return Direction * Magnitude;
    }
}