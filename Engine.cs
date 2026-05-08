using Raylib_cs;

namespace CHIP8;

class Engine(int width, int height, string title, float scale)
{
    private Color[] pixel_buffer = new Color[64*32];
    private readonly Display display = new(width, height, title, scale);
    private CPU cpu = new();

    public void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            Update();
            Draw();
        }
    }

    private void Update()
    {

    }

    private void Draw() => display.Draw(ref pixel_buffer);
}