namespace Chip8App.Models;

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

  public void Execute(CPU cpu, ushort opcode)
  {
    switch (opcode & 0xF000)
    {
      case 0x0000: { SYS_ADR_0NNN(cpu, (ushort)(opcode & 0x0FFF)); } break;
      case 0x1000: { JP_ADR_1NNN(cpu, (ushort)(opcode & 0x0FFF)); } break;
      case 0x2000: { CALL_ADR_2NNN(cpu, (ushort)(opcode & 0x0FFF)); } break;
      case 0x3000: { SE_Vx_3XKK(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)(opcode & 0x00FF)); } break;
      case 0x4000: { SNE_Vx_4XKK(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)(opcode & 0x00FF)); } break;
      case 0x5000: { SE_VxVy_5XY0(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00F0) >> 1)); } break;
      case 0x6000: { LD_Vx_6XKK(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00FF) >> 1)); } break;
      case 0x7000: { ADD_Vx_7XKK(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00FF))); } break;
      case 0x8000:
        switch (opcode & 0x000F)
        {
          case 0x0000: { LD_VxVy_8XY0(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00F0) >> 1)); } break;
          case 0x0001: { OR_VxVy_8XY1(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00F0) >> 1)); } break;
          case 0x0002: { AND_VxVy_8XY2(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00F0) >> 1)); } break;
          case 0x0003: { XOR_VxVy_8XY3(cpu), (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00F0) >> 1); } break;
          case 0x0004: { ADD_VxVy_8XY4(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00F0) >> 1)); } break;
          case 0x0005: { SUB_VxVy_8XY5(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00F0) >> 1)); } break;
          case 0x0006: { SHR_Vx_Vy_8XY6(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00F0) >> 1)); } break;
          case 0x0007: { SUBN_VxVy_8XY7(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00F0) >> 1)); } break;
          case 0x000E: { SHL_Vx_Vy_8XYE(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)((opcode & 0x00F0) >> 1)); } break;
        }
        break;
      case 0xA000: { LD_I_ADR_ANNN(cpu, (ushort)((opcode & 0x0FFF))); } break;
      case 0xB000: { JP_V0_ADR_BNNN(cpu, (ushort)((opcode & 0x0FFF))); } break;
      case 0xC000: { RND_Vx_BYTE_CXKK(cpu, (ushort)((opcode & 0x0F00) >> 2), (ushort)())} break;
      case 0xD000: break;
      case 0xE000: break;
      case 0xF000: break;
      default:
        throw new Exception($"Unknown opcode: {opcode:X4}");
    }
  }

  private void SYS_ADR_0NNN(CPU cpu, ushort opcode) => throw new NotImplementedException();
  private void CLS_00E0(CPU cpu, ushort opcode) => throw new NotImplementedException();
  private void RET_00EE(CPU cpu) => throw new NotImplementedException();
  private void JP_ADR_1NNN(CPU cpu, ushort nnn) => throw new NotImplementedException();
  private void CALL_ADR_2NNN(CPU cpu, ushort nnn) => throw new NotImplementedException();
  private void SE_Vx_3XKK(CPU cpu, ushort x, ushort kk) => throw new NotImplementedException();
  private void SNE_Vx_4XKK(CPU cpu, ushort x, ushort kk) => throw new NotImplementedException();
  private void SE_VxVy_5XY0(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void LD_Vx_6XKK(CPU cpu, ushort x, ushort kk) => throw new NotImplementedException();
  private void ADD_Vx_7XKK(CPU cpu, ushort x, ushort kk) => throw new NotImplementedException();
  private void LD_VxVy_8XY0(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void OR_VxVy_8XY1(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void AND_VxVy_8XY2(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void XOR_VxVy_8XY3(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void ADD_VxVy_8XY4(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void SUB_VxVy_8XY5(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void SHR_Vx_Vy_8XY6(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void SUBN_VxVy_8XY7(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void SHL_Vx_Vy_8XYE(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void SND_VxVy_9XY0(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void LD_I_ADR_ANNN(CPU cpu, ushort nnn) => throw new NotImplementedException();
  private void JP_V0_ADR_BNNN(CPU cpu, ushort nnn) => throw new NotImplementedException();
  private void RND_Vx_BYTE_CXKK(CPU cpu, ushort x, ushort kk) => throw new NotImplementedException();
  private void DRW_VxVy_NIBBLE_DXYN(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  private void SKP_Vx_EX9E(CPU cpu, ushort x) => throw new NotImplementedException();
  private void SKNP_Vx_EXA1(CPU cpu, ushort x) => throw new NotImplementedException();
  private void LD_Vx_dt_FX07(CPU cpu, ushort x) => throw new NotImplementedException();
  private void LD_VxK_FX0A(CPU cpu, ushort x) => throw new NotImplementedException();
  private void LD_dt_Vx_FX15(CPU cpu, ushort x) => throw new NotImplementedException();
  private void LD_st_Vx_FX18(CPU cpu, ushort x) => throw new NotImplementedException();
  private void ADD_IVx_FX1E(CPU cpu, ushort x) => throw new NotImplementedException();
  private void LD_FVx_FX29(CPU cpu, ushort x) => throw new NotImplementedException();
  private void LD_BVx_FX33(CPU cpu, ushort x) => throw new NotImplementedException();
  private void LD_ADRIVx_FX55(CPU cpu, ushort x) => throw new NotImplementedException();
  private void LD_VxADRI_FX65(CPU cpu, ushort x) => throw new NotImplementedException();
}
