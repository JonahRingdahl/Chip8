using System.Numerics;
using Raylib_cs;

namespace CHIP8.Models;

class Display
{
    Vector2 SCREEN_DIMENSIONS = new(1280, 720);
    Vector2 DISPLAY_DIMENSIONS = new(64, 32);
    Texture2D texture2D = new();
    private readonly float scale = 1;

    public Display(int width, int height, string title, float scale)
    {
        Raylib.InitWindow(width, height, title);
        Raylib.SetTargetFPS(60);

        Image img_display = Raylib.GenImageColor(64, 32, Color.Black);
        texture2D = Raylib.LoadTextureFromImage(img_display);
        Raylib.UnloadImage(img_display);
        this.scale = scale;
    }

    public void Draw(ref Color[] pixel_buffer)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.RayWhite);

        for (int i = 0; i < pixel_buffer.Length; i++)
        {
            var x = i % 64;
            var y = i / 64;

            pixel_buffer[i] = (i % 3) switch
            {
                0 => Color.Green,
                1 => Color.Red,
                2 => Color.Blue,
                _ => Color.Black,
            };
        }

        var screenWidth = Raylib.GetScreenWidth();
        var screenHeight = Raylib.GetScreenHeight();

        var chipWidth = 64 * scale;
        var chipHeight = 32 * scale;

        var x_offset = (screenWidth - chipWidth) / 2;
        var y_offset = (screenHeight - chipHeight) / 2;

        UpdateTextureUnsafe(texture2D, pixel_buffer);

        Raylib.DrawTextureEx(texture2D, 
        new Vector2(x_offset,y_offset),
        0,
        scale,
        Color.RayWhite
        );

        Raylib.EndDrawing();
    }

    unsafe void UpdateTextureUnsafe(Texture2D tex, Color[] gfx) {
        fixed (Color* ptr = gfx) {
            Raylib.UpdateTexture(tex, ptr);
        }
    }

    ~Display() => Raylib.CloseWindow();

}
