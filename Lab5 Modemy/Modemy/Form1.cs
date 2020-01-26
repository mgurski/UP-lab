using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Text;

namespace Modemy_Labsony
{
    public partial class Form1 : Form
    {
        SerialPort port = new SerialPort();
        public Form1()
        {
            InitializeComponent();
        }

        delegate void SetTextCallback(string text);

        private void WypiszNaEkran(String text)
        {
            if (konsola.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(WypiszNaEkran);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                konsola.Text += text;
                konsola.SelectionStart = konsola.TextLength;
                konsola.ScrollToCaret();
            }
        }

        private void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = port.ReadExisting();
            if (data.Contains("CON"))
            {
                WypiszNaEkran("Polaczono z drugim modemem");
            }
            WypiszNaEkran(data);
            if(checkBoxRecieve.Checked)
            {
                using (FileStream fs = new FileStream("test2.txt", FileMode.Append))
                {
                    byte[] arr = Encoding.ASCII.GetBytes(data);
                    fs.Write(arr, 0, data.Length);
                }
            }
        }

        private void polaczSzeregowoButton_Click(object sender, EventArgs e)
        {
            if (!port.IsOpen)
            {
                port.PortName = "COM1";
                port.Parity = Parity.None;
                port.DataBits = 8;
                port.BaudRate = 9600;
                port.StopBits = StopBits.One;
                port.Handshake = Handshake.RequestToSend;
                port.DataReceived += dataReceived;
                port.RtsEnable = true;
                port.DtrEnable = true;

                port.WriteTimeout = 500;
                port.ReadTimeout = 500;
                
                try
                {
                    port.Open();
                    WypiszNaEkran("Nawiazano polaczenie." + Environment.NewLine);
                }
                catch(Exception ex)
                {
                    WypiszNaEkran(ex.Message);
                }
            }
        }

        private void zerwijPolaczenieZModememButton_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.Write("ATH\r");
                port.Close();
                WypiszNaEkran("Zerwano polaczenie z modemem." + Environment.NewLine);
            }
        }

        private void wysliJWiadomosc()
        {
            if (port.IsOpen)
            {
                port.Write(wiadomoscInput.Text + "\r");
                WypiszNaEkran("\n->" + wiadomoscInput.Text + Environment.NewLine);
            }
        }

        private void zadzwonButton_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.Write("ATD" + numerModemu.Text + "\r");
                WypiszNaEkran("-> Dzwonie pod numer ATD" + numerModemu.Text + Environment.NewLine);
            }
        }

        private void odbierzButton_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.Write("ATA\r");
                WypiszNaEkran("Odbieranie...");
            }
        }

        private void zerwijPolaczenieButton_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                WypiszNaEkran("Zrywanie..." + Environment.NewLine);
                port.Write("+");
                Thread.Sleep(100);
                port.Write("+");
                Thread.Sleep(100);
                port.Write("+");
                Thread.Sleep(100);
                Thread.Sleep(1000);
                port.Write("ATH\r");
                Thread.Sleep(5000);
                port.Write("ATH\r");
            }
        }

        public void SendFile()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            if (String.IsNullOrEmpty(fd.FileName))
                return;
            else if (port.IsOpen)
            {
                using (FileStream fs = File.OpenRead(fd.FileName))
                {
                    port.Write((new BinaryReader(fs)).ReadBytes
                        ((int)fs.Length), 0, (int)fs.Length);
                }
            }
        }

        private void wiadomoscInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                wysliJWiadomosc();
                wiadomoscInput.Clear();
            }
        }

        private void buttonSendFile_Click(object sender, EventArgs e)
        {
            SendFile();
        }

        private void buttonRecieve_Click(object sender, EventArgs e)
        {
            var data = port.ReadExisting();
            if (data.Contains("CON"))
            {
                WypiszNaEkran("Polaczono z drugim modemem");
            }
        }
    }
}
