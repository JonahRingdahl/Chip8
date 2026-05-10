using System.Numerics;
using Raylib_cs;

namespace Chip8App.Models;

class Display
{
  public const int SCREEN_WIDTH = 1280;
  public const int SCREEN_HEIGHT = 720;
  public const int DISPLAY_WIDTH = 64;
  public const int DISPLAY_HEIGHT = 32;
  Texture2D texture2D = new();
  private readonly float scale = 1;
  public Color[] PixelBuffer { get; } =
      new Color[DISPLAY_WIDTH * DISPLAY_HEIGHT];

  public Display(int width, int height, string title, float scale)
  {
    Raylib.InitWindow(width, height, title);
    Raylib.SetTargetFPS(60);

    Image img_display = Raylib.GenImageColor(DISPLAY_WIDTH, DISPLAY_HEIGHT, Color.Black);
    texture2D = Raylib.LoadTextureFromImage(img_display);

    Raylib.UnloadImage(img_display);
    this.scale = scale;
  }

  public bool DrawSinglePixel(int x, int y, Color color)
  {
    var idx = (y * DISPLAY_WIDTH) + x;

    if (idx < 0 || idx >= PixelBuffer.Length) return false;

    PixelBuffer[idx] = color;
    return true;
  }

  public void Draw()
  {
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);

    for (int i = 0; i < PixelBuffer.Length; i++)
    {
      PixelBuffer[i] = (i % 3) switch
      {
        0 => Color.Green,
        1 => Color.Red,
        2 => Color.Blue,
        _ => Color.Black,
      };
    }

    var screenWidth = Raylib.GetScreenWidth();
    var chipWidth = 64 * scale;
    var x_offset = (screenWidth - chipWidth) / 2;

    UpdateTextureUnsafe(texture2D, PixelBuffer);

    Raylib.DrawTextureEx(texture2D,
        new Vector2(x_offset, 0),
        0,
        scale,
        Color.RayWhite
    );

    Raylib.EndDrawing();
  }

  unsafe void UpdateTextureUnsafe(Texture2D tex, Color[] gfx)
  {
    fixed (Color* ptr = gfx)
    {
      Raylib.UpdateTexture(tex, ptr);
    }
  }

  ~Display() => Raylib.CloseWindow();

}
