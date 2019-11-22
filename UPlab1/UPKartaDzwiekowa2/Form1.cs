using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.DirectSound;
using SharpDX.Multimedia;
using System;
using SharpDX;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SharpDX.DirectInput;
using System.Windows.Input;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace UPKartaDzwiekowa2
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        IPlayer player;
        DirectXRecorder rec;
        string path = string.Empty;
        [DllImport("winmm.dll", SetLastError = true)]
        private static extern bool PlaySound(string pszSound, UIntPtr hmod, uint fdwSound);

        [System.Flags]
        private enum SoundFlags : int
        {
            /// <summary>play asynchronously</summary>
            SND_ASYNC = 0x0001,
            /// <summary>loop the sound until next sndPlaySound</summary>
            SND_LOOP = 0x0008,
            /// <summary>name is file name</summary>
            SND_FILENAME = 0x00020000
        }

        public Form1()
        {
            
            InitializeComponent();
            openFileDialog.ShowDialog();
            if (!openFileDialog.CheckFileExists) return;
            path = openFileDialog.FileName;
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;

            progressBar2.Maximum = 100;
            progressBar2.Minimum = 0;
            progressBar2.Value = 0;

            progressBar3.Maximum = 100;
            progressBar3.Minimum = 0;
            progressBar3.Value = 0;

            progressBar4.Maximum = 100;
            progressBar4.Minimum = 0;
            progressBar4.Value = 0;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (path.Length > 0)
                PlaySound(path, UIntPtr.Zero, (uint)(SoundFlags.SND_FILENAME | SoundFlags.SND_ASYNC | SoundFlags.SND_LOOP));
        }

        private void buttonPlayDirectX_Click(object sender, EventArgs e)
        {
            if (path.Length > 0)
            {
                player = new DirectXPlayer(path, Handle);
                player.Play();
            }
            var reader = new BinaryReader(File.OpenRead(path));

            var chunkId = new string(reader.ReadChars(4));
            var chunkSize = reader.ReadInt32();
            var format = new string(reader.ReadChars(4));
            var subChunkId = new string(reader.ReadChars(4));
            var subChunkSize = reader.ReadInt32();
            var audioFormat = (WaveFormatEncoding)reader.ReadInt16();
            var numChannels = reader.ReadInt16();
            var sampleRate = reader.ReadInt32();
            var bytesPerSecond = reader.ReadInt32();
            var blockAlign = reader.ReadInt16();
            var bitsPerSample = reader.ReadInt16();
            var dataChunkId = new string(reader.ReadChars(4));
            var dataSize = reader.ReadInt32();

            string info = chunkId.ToString() + " " + chunkSize.ToString() + " " + format.ToString() + " " + subChunkId.ToString() + "\n" +
                subChunkSize.ToString() + " " + audioFormat.ToString() + " " + numChannels.ToString() + " " + sampleRate.ToString() + "\n" +
                bytesPerSecond.ToString() + " " + blockAlign.ToString() + " " + bitsPerSample.ToString() + " " + dataChunkId.ToString() + " " + dataSize.ToString();
            MessageBox.Show(info);
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            comboBox1.Items.AddRange(devices.ToArray());

            timer1.Start();
        }

        private void buttonWaveOutWrite_Click(object sender, EventArgs e)
        {
            player = new WaveOutWrite(path);
            player.Play();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void buttonWMP_Click(object sender, EventArgs e)
        {
            player = new WindowsMediaPlayer(path);
            player.Play();
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            rec = new DirectXRecorder(Handle);
            rec.Start();
        }

        private void buttonStopRec_Click(object sender, EventArgs e)
        {
            rec.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                var device = (MMDevice)comboBox1.SelectedItem;
                var values = device.AudioMeterInformation.PeakValues;
                progressBar1.Value = (int)(device.AudioMeterInformation.MasterPeakValue*100+0.5);
            }
        }
    }
}
