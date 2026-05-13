namespace Chip8App.Models;
// http://devernay.free.fr/hacks/chip8/chip8def.htm
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
      case 0x0000: switch (opcode & 0x00FF)
        {
          case 0x0000: { SYS_ADR_0NNN(cpu, (ushort) (opcode & 0x0FFF)); } break;
          case 0x00E0: { CLS_00E0(cpu, opcode); } break;
          case 0x00EE: { RET_00EE(cpu); } break;
        } break;

      case 0x1000: { JP_ADR_1NNN(cpu, (ushort) (opcode & 0x0FFF)); } break;
      case 0x2000: { CALL_ADR_2NNN(cpu, (ushort) (opcode & 0x0FFF)); } break;
      case 0x3000: { SE_Vx_3XKK(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) (opcode & 0x00FF)); } break;
      case 0x4000: { SNE_Vx_4XKK(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) (opcode & 0x00FF)); } break;
      case 0x5000: { SE_VxVy_5XY0(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00F0) >> 1)); } break;
      case 0x6000: { LD_Vx_6XKK(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00FF) >> 1)); } break;
      case 0x7000: { ADD_Vx_7XKK(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00FF))); } break;
      case 0x8000: switch (opcode & 0x000F)
                   {
                     case 0x0000: { LD_VxVy_8XY0(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00F0) >> 1)); } break;
                     case 0x0001: { OR_VxVy_8XY1(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00F0) >> 1)); } break;
                     case 0x0002: { AND_VxVy_8XY2(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00F0) >> 1)); } break;
                     case 0x0003: { XOR_VxVy_8XY3(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00F0) >> 1)); } break;
                     case 0x0004: { ADD_VxVy_8XY4(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00F0) >> 1)); } break;
                     case 0x0005: { SUB_VxVy_8XY5(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00F0) >> 1)); } break;
                     case 0x0006: { SHR_Vx_Vy_8XY6(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00F0) >> 1)); } break;
                     case 0x0007: { SUBN_VxVy_8XY7(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00F0) >> 1)); } break;
                     case 0x000E: { SHL_Vx_Vy_8XYE(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) ((opcode & 0x00F0) >> 1)); } break;
                   } break;
      case 0x9000: break;

      case 0xA000: { LD_I_ADR_ANNN(cpu, (ushort) (opcode & 0x0FFF)); } break;
      case 0xB000: { JP_V0_ADR_BNNN(cpu, (ushort) (opcode & 0x0FFF)); } break;
      case 0xC000: { RND_Vx_BYTE_CXKK(cpu, (ushort) ((opcode & 0x0F00) >> 2), (ushort) (opcode & 0x00FF)); }break;
      case 0xD000: break;
      case 0xE000: break;
      case 0xF000: break;
      default:
        throw new Exception($"Unknown opcode: {opcode:X4}");
    }
  }

#region OPCODES

  /// <summary>
  ///   Scroll the screen down x lines	Super only, not implemented
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="opcode"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void SYS_ADR_0NNN(CPU cpu, ushort opcode) => throw new NotImplementedException();

  /// <summary>
  ///   Clear the screen
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="opcode"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void CLS_00E0(CPU cpu, ushort opcode) => throw new NotImplementedException();

  /// <summary>
  ///   return from subroutine call
  /// </summary>
  /// <param name="cpu"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void RET_00EE(CPU cpu) => throw new NotImplementedException();

  /// <summary>
  ///   jump to address xxx
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="nnn"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void JP_ADR_1NNN(CPU cpu, ushort nnn) => throw new NotImplementedException();

  /// <summary>
  ///   jump to subroutine at address xxx	16 levels maximum
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="nnn"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void CALL_ADR_2NNN(CPU cpu, ushort nnn) => throw new NotImplementedException();

  /// <summary>
  ///   skip if register r = constant
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="kk"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void SE_Vx_3XKK(CPU cpu, ushort x, ushort kk) => throw new NotImplementedException();
  
  /// <summary>
  ///   skip if register r <> constant
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="kk"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void SNE_Vx_4XKK(CPU cpu, ushort x, ushort kk) => throw new NotImplementedException();
  
  /// <summary>
  ///   skip f register r = register y
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void SE_VxVy_5XY0(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  
  /// <summary>
  ///   move constant to register r
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="kk"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void LD_Vx_6XKK(CPU cpu, ushort x, ushort kk) => throw new NotImplementedException();
  
  /// <summary>
  ///   add constant to register r	No carry generated
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="kk"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void ADD_Vx_7XKK(CPU cpu, ushort x, ushort kk) => throw new NotImplementedException();
  
  /// <summary>
  ///   move register vy into vx
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void LD_VxVy_8XY0(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  
  /// <summary>
  ///   or register vy into register vx
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void OR_VxVy_8XY1(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  
  /// <summary>
  /// 	and register vy into register vx
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void AND_VxVy_8XY2(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  
  /// <summary>
  ///   exclusive or register ry into register rx
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void XOR_VxVy_8XY3(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  
  /// <summary>
  /// add register vy to vx,carry in vf
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void ADD_VxVy_8XY4(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  
  /// <summary>
  ///   	subtract register vy from vr,borrow in vf	vf set to 1 if borroesws
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void SUB_VxVy_8XY5(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  
  /// <summary>
  ///   shift register vy right, bit 0 goes into register vf
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void SHR_Vx_Vy_8XY6(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  
  /// <summary>
  ///   	subtract register vr from register vy, result in vr	vf set to 1 if borrows
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void SUBN_VxVy_8XY7(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  
  /// <summary>
  /// 	shift register vr left,bit 7 goes into register vf
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void SHL_Vx_Vy_8XYE(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  
  /// <summary>
  /// 	skip if register rx <> register ry
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void SND_VxVy_9XY0(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();
  
  /// <summary>
  /// 	Load index register with constant nnn
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="nnn"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void LD_I_ADR_ANNN(CPU cpu, ushort nnn) => throw new NotImplementedException();
  
  /// <summary>
  ///   Jump to address nnn+register v0
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="nnn"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void JP_V0_ADR_BNNN(CPU cpu, ushort nnn) => throw new NotImplementedException();
  
  /// <summary>
  /// vx = random number less than or equal to kkk
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="kk"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void RND_Vx_BYTE_CXKK(CPU cpu, ushort x, ushort kk) => throw new NotImplementedException();
  
  /// <summary>
  ///   Draw sprite at screen location rx,ry height s	
  ///     Sprites stored in memory at location in index register, 
  ///     maximum 8 bits wide. 
  ///     Wraps around the screen. If when drawn, clears a pixel, 
  ///     vf is set to 1 otherwise it is zero. 
  ///     All drawing is xor drawing (e.g. it toggles the screen pixels
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <param name="y"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void DRW_VxVy_NIBBLE_DXYN(CPU cpu, ushort x, ushort y) => throw new NotImplementedException();

  /// <summary>
  ///   skip if key (register rk) pressed	The key is a key number, 
  ///   see the chip-8 documentation
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void SKP_Vx_EX9E(CPU cpu, ushort x) => throw new NotImplementedException();
  
  /// <summary>
  ///   skip if key (register rk) not pressed
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void SKNP_Vx_EXA1(CPU cpu, ushort x) => throw new NotImplementedException();
  
  /// <summary>
  ///   get delay timer into vr
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void LD_Vx_dt_FX07(CPU cpu, ushort x) => throw new NotImplementedException();
  
  /// <summary>
  ///   wait for for keypress,put key in register vr
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void LD_VxK_FX0A(CPU cpu, ushort x) => throw new NotImplementedException();
  
  /// <summary>
  ///   set the delay timer to vr
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void LD_dt_Vx_FX15(CPU cpu, ushort x) => throw new NotImplementedException();
  
  /// <summary>
  ///   set the sound timer to vr
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void LD_st_Vx_FX18(CPU cpu, ushort x) => throw new NotImplementedException();
  
  /// <summary>
  ///   add register vr to the index register
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void ADD_IVx_FX1E(CPU cpu, ushort x) => throw new NotImplementedException();
  
  /// <summary>
  ///   point I to the sprite for hexadecimal character in vr	Sprite is 5 bytes high
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void LD_FVx_FX29(CPU cpu, ushort x) => throw new NotImplementedException();
  
  /// <summary>
  ///   store the bcd representation of register vr at location I,I+1,I+2	Doesn't change I
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void LD_BVx_FX33(CPU cpu, ushort x) => throw new NotImplementedException();
  
  /// <summary>
  ///   store registers v0-vr at location I onwards	I is incremented 
  ///     to point to the next location on. 
  ///   
  ///   e.g. I = I + r + 1
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void LD_ADRIVx_FX55(CPU cpu, ushort x) => throw new NotImplementedException();
  
  /// <summary>
  ///   load registers v0-vr from location I onwards	as above.
  /// </summary>
  /// <param name="cpu"></param>
  /// <param name="x"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void LD_VxADRI_FX65(CPU cpu, ushort x) => throw new NotImplementedException();

  #endregion
}
