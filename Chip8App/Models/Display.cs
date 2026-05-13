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

  public Display(int width, int height, string title, float scale)
  {
    Raylib.InitWindow(width, height, title);
    Raylib.SetTargetFPS(60);

    Image img_display = Raylib.GenImageColor(DISPLAY_WIDTH, DISPLAY_HEIGHT, Color.Black);
    texture2D = Raylib.LoadTextureFromImage(img_display);

    Raylib.UnloadImage(img_display);
    this.scale = scale;
  }

  public static bool DrawSinglePixel(int x, int y, bool on, ref bool[] display_buffer)
  {
    var idx = (y * DISPLAY_WIDTH) + x;

    if (idx < 0 || idx >= display_buffer.Length) return false;

    display_buffer[idx] = on;
    return true;
  }

  public static bool NumIntoBuffer(Vector2 start, ushort data, ref bool[] display_buffer)
  {
    var x = (int)start.X;
    var y = (int)start.Y;

    for (int i = 0; i < 16; i++)
    {
      int bitIdx = 15 - i;
      bool bit = ((data >> bitIdx) & 1) == 1;

      int bufferIdx = (y * DISPLAY_WIDTH) + x + i;

      if (bufferIdx < 0 || bufferIdx >= display_buffer.Length) return false;

      display_buffer[bufferIdx] = bit;
    }

    return true;
  }
  public void Draw(ref bool[] display_buffer)
  {
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.RayWhite);

    var color_buffer = new Color[display_buffer.Length];

    for (int i = 0; 0 < display_buffer.Length; i++)
    {
      color_buffer[i] = display_buffer[i] ? Color.Black : Color.White;
    }

    var screenWidth = Raylib.GetScreenWidth();
    var chipWidth = 64 * scale;
    var x_offset = (screenWidth - chipWidth) / 2;

    UpdateTextureUnsafe(texture2D, color_buffer);

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

  public static readonly ushort[] ZERO = [
    0xF0,
    0x90,
    0x90,
    0x90,
    0xF0,
  ];
  public static readonly ushort[] ONE = [
    0x20,
    0x60,
    0x20,
    0x20,
    0x70
  ];
  public static readonly ushort[] TWO = [
    0xF0,
    0x10,
    0xF0,
    0x80,
    0xF0
  ];
  public static readonly ushort[] THREE = [
    0xF0,
    0x10,
    0xF0,
    0x10,
    0xF0,
  ];
  public static readonly ushort[] FOUR = [
    0x90,
    0x90,
    0xF0,
    0x10,
    0x10
  ];
  public static readonly ushort[] FIVE = [
    0xF0,
    0x80,
    0xF0,
    0x10,
    0xF0
  ];
  public static readonly ushort[] SIX = [
    0xF0,
    0x80,
    0xF0,
    0x90,
    0xF0
  ];
  public static readonly ushort[] Seven = [
    0xF0,
    0x10,
    0x20,
    0x40,
    0x40
  ];
  public static readonly ushort[] EIGHT = [
    0xF0,
    0x90,
    0xF0,
    0x90,
    0xF0,
  ];
  public static readonly ushort[] NINE = [
    0xF0,
    0x90,
    0xF0,
    0x10,
    0xF0
  ];
  public static readonly ushort[] A = [
    0xF0,
    0x90,
    0xF0,
    0x90,
    0xF0
  ];
  public static readonly ushort[] B = [
    0xE0,
    0x90,
    0xE0,
    0x90,
    0xE0
  ];
  public static readonly ushort[] C = [
    0xF0,
    0x80,
    0x80,
    0x80,
    0xF0
  ];
  public static readonly ushort[] D = [
    0xE0,
    0x90,
    0x90,
    0x90,
    0xE0,
  ];
  public static readonly ushort[] E = [
    0xF0,
    0x80,
    0xF0,
    0x80,
    0xF0
  ];
  public static readonly ushort[] F = [
    0xF0,
    0x80,
    0xF0,
    0x80,
    0x80
  ];
}
