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
        //169.254.2.10
        private void timerRead_Tick(object sender, EventArgs e)
        {
            timerRead.Enabled = false;
            textBox1.Text = "";
            int[] current;
            int[] voltage;
            int[] power;
            int[] apppower;
            int[] reactpower;
            voltage = modbusClient.ReadHoldingRegisters(4164, 2);
            current = modbusClient.ReadHoldingRegisters(4112, 2);
            power = modbusClient.ReadHoldingRegisters(4144, 2);
            apppower = modbusClient.ReadHoldingRegisters(4136, 2);
            reactpower = modbusClient.ReadHoldingRegisters(4152, 2);
            textBox1.Text = "Voltage: " + voltage[1].ToString() + "[V]  Current: 0." + current[1].ToString() + "[A]";
            textBox2.Text = "Power: 0. " + power[1].ToString() + "[kW]  Apparent Power: 0." + apppower[1].ToString() + "[kVA]";
            textBox3.Text = "Reactive Power: " + (reactpower[1]/1000.0).ToString() + "kvar";
            progressBarValue.Value = voltage[1];
            labelValue.Text = voltage[1].ToString();
            progressBarValue.Refresh();

            timerRead.Enabled = true;
        }
    }
}
