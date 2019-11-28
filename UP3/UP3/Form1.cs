using EasyModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP3
{
    public partial class Form1 : Form
    {
        ModbusClient modbusClient = null;
        public Form1()
        {
            InitializeComponent();
            //modbusClient.Baudrate = 9600;	// Not necessary since default baudrate = 9600
            //modbusClient.Parity = System.IO.Ports.Parity.None;
            //modbusClient.StopBits = System.IO.Ports.StopBits.Two;
            //modbusClient.ConnectionTimeout = 500;
            progressBarValue.Minimum = 0;
            progressBarValue.Maximum = 500;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            modbusClient = new ModbusClient(textBoxIP.Text, 502);
            modbusClient.UnitIdentifier = 0x01;
            try
            {
                modbusClient.Connect();
            }
            catch
            {
                MessageBox.Show("Nie można utworzyć połączenia");
            }
            if (modbusClient.Connected)
            {
                this.Text = "Connected to " + textBoxIP.Text;
                timerRead.Start();
            }
            else
                MessageBox.Show("Nie można utworzyć połączenia");
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if(modbusClient == null)
            {
                this.Text = "ModBus nie istnieje";
                return;
            }
            try
            {
                timerRead.Stop();
                modbusClient.Disconnect();
            }
            catch
            {
                MessageBox.Show("Cannot disconect");
            }
            if (!modbusClient.Connected)
                this.Text = "Disconnected";
            else
                MessageBox.Show("Cannot disconect");
        }

        private void timerRead_Tick(object sender, EventArgs e)
        {
            timerRead.Enabled = false;

            modbusClient.WriteMultipleCoils(4, new bool[] { true, true, true, true, true, true, true, true, true, true });    //Write Coils starting with Address 5
            bool[] readCoils = modbusClient.ReadCoils(9, 10);                        //Read 10 Coils from Server, starting with address 10
            int[] readHoldingRegisters = modbusClient.ReadHoldingRegisters(0, 10);    //Read 10 Holding Registers from Server, starting with Address 1

            progressBarValue.Value = readHoldingRegisters[0];
            progressBarValue.Refresh();

            timerRead.Enabled = true;
        }
    }
}
