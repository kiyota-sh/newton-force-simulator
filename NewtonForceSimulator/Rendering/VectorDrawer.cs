using System.Numerics;
using Raylib_cs;

namespace NewtonForceSimulator.Rendering;

public sealed class VectorDrawer
{
    public void DrawArrow(
        Vector2 start,
        Vector2 vector,
        float tickness,
        Color color,
        string label)
    {
        Vector2 end = start + vector;
        
        Raylib.DrawLineEx(start, end, tickness, color);
        
        DrawArrowHead(start, end, 4f, color);
        
        Raylib.DrawText(
            label,
            (int)end.X + 10,
            (int)end.Y - 20,
            30,
            color);
    }

    private void DrawArrowHead(
        Vector2 start,
        Vector2 end,
        float tickness,
        Color color,
        float arrowSize = 15f)
    {
        Vector2 direction = Vector2.Normalize(end - start);

        Vector2 right = Rotoate(direction, 150f) * arrowSize;
        Vector2 left = Rotoate(direction, -150f) * arrowSize;
        
        Raylib.DrawLineEx(end, end + right, tickness, color);
        Raylib.DrawLineEx(end, end + left, tickness, color);
    }

    private Vector2 Rotoate(Vector2 vector, float degrees)
    {
        float radians = MathF.PI / 180f * degrees;

        float cos = MathF.Cos(radians);
        float sin = MathF.Sin(radians);

        return new Vector2(
            vector.X * cos - vector.Y * sin,
            vector.X * sin + vector.Y * cos);
    }
}