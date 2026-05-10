using System;
using Raylib_cs;

namespace Chip8App.Models;

public class Audio
{
  AudioStream audioStream = new();
  public Audio()
  {
    Raylib.InitAudioDevice();

  }

  public void Play()
  {
  }

  ~Audio()
  {
    Raylib.CloseAudioDevice();
  }

}
