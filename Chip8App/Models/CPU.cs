namespace CHIP8.Models;

class CPU()
{
    byte[] V = new byte[16];
    byte dt = 255;
    byte st = 255;
    UInt16 pc = 0;
    UInt16 sp = 0;


    public void Tick()
    {

    }
}