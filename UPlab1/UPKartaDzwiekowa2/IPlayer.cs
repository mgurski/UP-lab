using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPKartaDzwiekowa2
{
    interface IPlayer
    {
        string FileName { get; }
        bool IsPausable { get; }

        int GetFreq();
        void Play();
        void Pause();
        void Stop();
    }
}
