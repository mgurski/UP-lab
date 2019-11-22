using SharpDX.DirectInput;
using SharpDX.DirectSound;
using SharpDX.Multimedia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPKartaDzwiekowa2
{
    class DirectXRecorder
    {
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string strCommand,
        StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        [DllImport("winmm.dll")]
        public static extern int mciGetErrorString(int errCode,
                      StringBuilder errMsg, int buflen);


        Random randomNumber;
        private StringBuilder msg;  // MCI Error message
        private StringBuilder returnData;  // MCI return data
        private int error;
        private string Pcommand;  // String that holds the MCI command
        private ListView playlist;  // ListView as a playlist with the song path
        public int NowPlaying { get; set; }
        public bool Paused { get; set; }
        public bool Loop { get; set; }
        public bool Shuffle { get; set; }


        CaptureBuffer captureBuffer;
        CaptureBufferDescription captureDes = new CaptureBufferDescription();
        WaveFormat waveFormat = new WaveFormat();
        DirectSoundCapture captureDevice = new DirectSoundCapture();
        Device sndDevice;
        SecondarySoundBuffer buffer;
        StreamWriter wStream;
        StreamReader wReader;
        char[] bytes;
        char[] bytesRead;

        public DirectXRecorder(IntPtr handle)
        {
            captureDes.BufferBytes = 1920000;
            captureDes.Format = waveFormat;
            captureDes.Format = waveFormat;
            captureDes.BufferBytes = 1000000;



            captureDes.BufferBytes = 1920000;
            captureDes.Format = waveFormat;
            captureDes.BufferBytes = 1000000;
            captureBuffer = new CaptureBuffer(captureDevice, captureDes);
            bytes = new char[1000000];
            bytesRead = new char[1000000];
        }

        public void Start()
        {
            wStream = new StreamWriter("test.wav");
            captureBuffer.Start(true);
            for (int i = 0; i < 1000000; i++)
            {
                bytes[i] = (char)captureBuffer.Capabilities.BufferBytes;
                wStream.Write(bytes[i]);
            }
        }

        public void Stop()
        {
            captureBuffer.Stop();
            wStream.Close();
        }

        public void Close()
        {
        }


        public bool Open(string sFileName)
        {
            Close();
            // Try to open as mpegvideo 
            Pcommand = "open \"" + sFileName +
                       "\" type mpegvideo alias MediaFile";
            error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
            if (error != 0)
            {
                // Let MCI deside which file type the song is
                Pcommand = "open \"" + sFileName +
                           "\" alias MediaFile";
                error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
                if (error == 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
    }
}
