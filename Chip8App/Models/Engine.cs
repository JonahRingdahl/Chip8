using Raylib_cs;

namespace Chip8App.Models;

class Engine(int width, int height, string title, float scale)
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
