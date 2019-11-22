using SharpDX.DirectSound;
using SharpDX.Multimedia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UPKartaDzwiekowa2
{
    class DirectXPlayer : IPlayer
    {
        public DirectXPlayer(string fileName, IntPtr handle)
        {
            FileName = fileName;
            _secondaryBuffer = initializeSecondaryBuffer(fileName, handle);
        }

        public string FileName { get; }

        public bool IsPausable { get; } = true;

        private SecondarySoundBuffer _secondaryBuffer;

        private SecondarySoundBuffer initializeSecondaryBuffer(string fileName, IntPtr handle)
        {
            var directSound = new DirectSound();
            directSound.SetCooperativeLevel(handle, CooperativeLevel.Exclusive);

            var reader = new BinaryReader(File.OpenRead(FileName));

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

            var buffer = new SoundBufferDescription
            {
                Flags = BufferFlags.ControlVolume,
                BufferBytes = dataSize,
                Format = new WaveFormat(44100, 16, 2),
                AlgorithmFor3D = Guid.Empty
            };
            var secondaryBuffer = new SecondarySoundBuffer(directSound, buffer);

            var waveData = reader.ReadBytes(dataSize);

            reader.Close();

            var waveBufferData1 = secondaryBuffer.Lock(0, dataSize, LockFlags.None, out var waveBufferData2);

            waveBufferData1.Write(waveData, 0, dataSize);

            secondaryBuffer.Unlock(waveBufferData1, waveBufferData2);

            return secondaryBuffer;
        }

        public int GetFreq()
        {
            try
            {
                return _secondaryBuffer.Frequency;
            }
            catch
            {
                return 10;
            }
        }

        public void Play()
        {
            _secondaryBuffer.Play(0, PlayFlags.Looping);
        }

        public void Pause()
        {
            _secondaryBuffer.Stop();
        }

        public void Stop()
        {
            _secondaryBuffer.Stop();
            _secondaryBuffer.CurrentPosition = 0;
        }
    }
}
