using System.Numerics;
using NewtonForceSimulator.Models;
using Raylib_cs;

namespace NewtonForceSimulator.Rendering;

public sealed class DiagramRenderer
{
    private readonly VectorDrawer _vectorDrawer;

    public DiagramRenderer()
    {
        _vectorDrawer = new ();
    }

    public void DrawBlock(Block block, float planeAngle)
    {
        Rectangle rectangle = new(
            block.Position.X,
            block.Position.Y,
            block.Size,
            block.Size);

        Vector2 origin = new(
            block.Size / 2f,
            block.Size / 2f);
        
        Raylib.DrawRectanglePro(
            rectangle,
            origin,
            - planeAngle,
            Color.Red);
    }

    public void DrawForce(
        Block block,
        Force force,
        float scale = 1f)
    {
        Vector2 start = block.Position;
        Vector2 vector = force.GetVector() * scale;
        
        _vectorDrawer.DrawArrow(
            start,
            vector,
            3f,
            force.Color,
            force.Name);
    }
}