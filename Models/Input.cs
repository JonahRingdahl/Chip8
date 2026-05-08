using System;
using System.Collections;
using System.Numerics;
using Raylib_cs;

namespace Chip8.Models;

public class Input
{
    private const ushort KEY_WIDTH = 4;
    private ushort key_padding = 1;
    Rectangle[] key_display = new Rectangle[KEY_WIDTH * KEY_WIDTH];

    public Input(Vector2 boardPosition, ushort padding)
    {
        
    }




    public void Draw()
    {

    }

    public void Update()
    {

    }

    private void DrawBoard()
    {


    }
}

[Flags]
public enum Keys
{
    Zero = 0,
    One = 1 << 0,
    Two = 1 << 1,
    Three = 1 << 2,
    Four = 1 << 3,
    Five = 1 << 4,
    Six = 1 << 5,
    Seven = 1 << 6,
    Eight = 1 << 7,
    Nine = 1 << 8,
    A = 1 << 9,
    B = 1 << 10,
    C = 1 << 11,
    D = 1 << 12,
    E = 1 << 13,
    F = 1 << 14
}