﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPKartaDzwiekowa2
{
    class WindowsMediaPlayer : IPlayer
    {

        public WindowsMediaPlayer(string fileName)
        {
            wmPlayer = new WMPLib.WindowsMediaPlayer();
            FileName = fileName;
            wmPlayer.settings.autoStart = false;
            wmPlayer.URL = FileName;
        }

        public WMPLib.WindowsMediaPlayer wmPlayer;

        public string FileName { get; }

        public bool IsPausable { get; } = true;

        public void Play()
        {
            wmPlayer.controls.play();
        }

        public void Pause()
        {
            wmPlayer.controls.pause();
        }

        public void Stop()
        {
            wmPlayer.controls.stop();
        }

        public int GetFreq()
        {
            throw new NotImplementedException();
        }
    }
}
