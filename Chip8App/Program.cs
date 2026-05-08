
///
/// Data Source :
///     Cowgod's Chip-8 Technical Reference v1.0
///     http://devernay.free.fr/hacks/chip8/C8TECH10.HTM
/// 
/// 

using CHIP8.Models;

const int WINDOW_WIDTH = 1280;
const int WINDOW_HEIGHT = 720;

var engine = new CHIP8.Models.Chip8(WINDOW_WIDTH, WINDOW_HEIGHT, "CHIP-8", 10);
engine.Run();