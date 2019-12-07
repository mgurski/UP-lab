using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCSC;
using PCSC.Exceptions;
using PCSC.Utils;

namespace CzytnikKart
{

    public partial class Czytnik : Form
    {

        private static SCardError error;
        private static SCardReader reader;
        private static SCardContext context;
        private static IntPtr protocol;

        public Czytnik()
        {
            InitializeComponent();
        }

        private void send(byte[] command, string command_name)
        {
            var response = new byte[256];

            reader.Transmit(protocol, command, ref response);


            var my_string = new StringBuilder();

            foreach (byte i in response)
            { 
                my_string.Append(string.Format("{0:X2} ", i));
            }

            var result = my_string.ToString();

            richTextBox1.Text = command_name + ": \n" + result;

            if(command_name == "Read record")
            {
                richTextBox1.AppendText("Response in ascii : \n");
                richTextBox1.AppendText(System.Text.Encoding.ASCII.GetString(response).ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //creating the context
            context = new SCardContext();
            context.Establish(SCardScope.System);

            //getting the reader
            string[] readers = context.GetReaders();
            
            reader = new SCardReader(context);

            //connecting 
            error = reader.Connect(readers[0], SCardShareMode.Shared, SCardProtocol.T0 | SCardProtocol.T1);

            //checking for errors
            if(error != SCardError.Success)
            {
                MessageBox.Show(SCardHelper.StringifyError(error));
            }

            //connected
            if (error == SCardError.Success)
            {
                label1.Text = "Connected to " + reader.ReaderName;
            }

            switch (reader.ActiveProtocol)
            {
                case SCardProtocol.T0:
                    protocol = SCardPCI.T0;
                    break;
                case SCardProtocol.T1:
                    protocol = SCardPCI.T1;
                    break;
                default:
                    throw new PCSCException(SCardError.CardUnsupported, "Not supported protocol");
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (reader.IsConnected)
            {
                reader.Disconnect(SCardReaderDisposition.Leave);
                label1.Text = "Not connected";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //select telecom
            byte[] s_telecom = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x7F, 0x10 };

            //get response
            byte[] g_respone = new byte[] { 0xA0, 0xC0, 0x00, 0x00, 0x0F };

            //se;ect sms
            byte[] s_sms = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x6F, 0x3C };

            //read record
            byte[] r_record = new byte[] { 0xA0, 0xB2, 0x01, 0x04, 0xB0 };

            switch (comboBox1.SelectedItem.ToString())
            {
                case "Select telecom":
                    send(s_telecom, "Select telecom");
                    break;
                case "Get response":
                    send(g_respone, "Get response");
                    break;
                case "Select sms":
                    send(s_sms, "Select sms");
                    break;
                case "Read record":
                    send(r_record, "Read record");
                    break;
                default:
                    break;
            }

        }
    }
}
