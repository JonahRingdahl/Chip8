using Chip8App.Models;
using Raylib_cs;

namespace CHIP8.Models;

class Chip8(int width, int height, string title, float scale)
{
    private Display display = new(width, height, title, scale);
    private Audio audio = new();
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

    private void Draw() => display.Draw();
    private void PlayAudio() => throw new NotImplementedException();
}