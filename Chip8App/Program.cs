using CHIP8.Models;

const int WINDOW_WIDTH = 1280;
const int WINDOW_HEIGHT = 720;

var engine = new Engine(WINDOW_WIDTH, WINDOW_HEIGHT, "CHIP-8", 10);
engine.Run();