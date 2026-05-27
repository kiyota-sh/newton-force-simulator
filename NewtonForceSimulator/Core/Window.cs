using NewtonForceSimulator.Rendering;
using Raylib_cs;

namespace NewtonForceSimulator.Core;

public class Window
{
    public readonly Renderer _renderer;
    
    public Window()
    {
        Raylib.InitWindow(Constants.ScreenWith, Constants.ScreenHeight, Constants.Title);
        Raylib.SetTargetFPS(Constants.TargetFps);
        _renderer = new();
    }

    public void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            float deltaTime = Raylib.GetFrameTime();
            Update(deltaTime);
            Draw();
        }
        
        Raylib.CloseWindow();
    }

    private void Update(float deltaTime)
    {
        _renderer.Update(deltaTime);
    }

    private void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(new Color(20, 20, 20));
        _renderer.Draw();
        Raylib.EndDrawing();
    }
}