using System;

namespace Chip8.Models;

public class Memory()
{
    private const uint MEMORY_END = 0xFFF;
    private const uint MEMORY_START = 0x0;
    private const uint MEMORY_PROGRAM_START = 0x200;
    private const uint MEMORY_ETI_660_PROGRAM_START = 0x600;
    private byte[] data = new byte[MEMORY_END];

}
