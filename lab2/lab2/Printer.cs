using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace lab2
{
    public partial class Printer : Form
    {
        public Printer()
        {
            InitializeComponent();
        }
        public string Font_type()
        {
            string ftype = " ";

            if (comboBox1.SelectedItem != null)
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Arial":
                        ftype = "(s218T";
                        break;
                    case "Courier":
                        ftype = "(s3T";
                        break;
                    default:
                        break;
                }
            }
            return ftype;
        }

        public string Font_size()
        {
            string fsize = "10";

            if (comboBox2.SelectedItem != null)
            {
                return comboBox2.SelectedItem.ToString();
            }

            return fsize;
        }

        public string Font_color()
        {
            string fcolor = "*v0S";

            if (comboBox3.SelectedItem != null)
            {
                switch (comboBox3.SelectedItem.ToString())
                {
                    case "Czerwony":
                        fcolor = "*v1S";
                        break;
                    case "Zielony":
                        fcolor = "*v2S";
                        break;
                    case "Niebieski":
                        fcolor = "*v12S";
                        break;
                    default:
                        break;
                }
            }

            return fcolor;
        }

        public bool Print()
        {
            string path = @".\file";
            FileStream file = File.Create(path);
            StreamWriter writer = new StreamWriter(file);

            string text = textBox1.Text;
               
            writer.WriteLine("\x1B" + "E");
            writer.WriteLine("\x1B" + "&s0C");
            writer.WriteLine("\x1B" + "&10O"); 
            writer.WriteLine("\x1B" + "*o0M"); 
            writer.WriteLine("\x1B" + "&l26A");

          
            //chosing the font type
            writer.WriteLine("\x1B" + Font_type());

            //chosing the font size

            writer.WriteLine("\x1B" + "(s" + Font_size() + "V");

            //chosing the font color
            writer.WriteLine("\x1B" + "*r3U");
            writer.WriteLine("\x1B" + Font_color());

            //bold
            if (checkBox1.Checked)
            {
                writer.WriteLine("\x1B" + "(s3B");
            }
            //italic
            if (checkBox2.Checked)
            {
                writer.WriteLine("\x1B" + "(s1S");
            }
            //underline
            if (checkBox3.Checked)
            {
                writer.WriteLine("\x1B" + "&d0D");
            }


            if (text.Equals(""))
                return false;

            writer.WriteLine(text);
            writer.WriteLine("\x1B" + "E");
            writer.Close();
            File.Copy(path, "LPT3");
          
            return true;
        }

        public bool PrintRaster()
        {
            string path = @".\file";
            FileStream file = File.Create(path);
            StreamWriter writer = new StreamWriter(file);

            writer.WriteLine("\x1B" + "E");

            //Simple color mode, -3 = 3 plates, CMY palette. 3 = 3 plates, RGB palette.
            writer.WriteLine("\x1B" + "*r-3U");

            //Start raster 
            writer.WriteLine("\x1B" + "r0A");

            //Compression method. 1 = Run-length encoding. Requies byte pairs.
            writer.WriteLine("\x1B" + "b1M");






            writer.WriteLine("\x1B" + "E");
            writer.Close();
            File.Copy(path, "LPT3");

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Print())
                MessageBox.Show("Nie udalo sie");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
