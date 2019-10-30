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
                        ftype = "(s16602T";
                        break;
                    case "Courier":
                        ftype = "(s4099T";
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
                        fcolor = "*v4S";
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

            //chosing the font color
            //simple color mode - 3 planes, RGB
            writer.WriteLine("\x1B" + "*r3U");
            writer.WriteLine("\x1B" + Font_color());

    
            if (text.Equals(""))
                return false;

            writer.WriteLine(text);
            writer.WriteLine("\x1B" + "E");
            writer.Close();
            File.Copy(path, "LPT3");
          
            return true;
        }

        public void PrintRaster()
        {
            string path = @".\file";
            FileStream file = File.Create(path);
            StreamWriter writer = new StreamWriter(file);

            writer.WriteLine("\x1B" + "E");

            //Simple color mode, -3 = 3 plates, CMY palette. 3 = 3 plates, RGB palette.
            writer.WriteLine("\x1B" + "*r-3U");

            //Start raster 
            writer.WriteLine("\x1B" + "*r1A");

            //Compression method. 1 = Run-length encoding. Requies byte pairs.
            writer.WriteLine("\x1B" + "*b1m");

            //simple 3 plane color graphics PCL ﬁle output that prints CMY colors
            //cyan data
            writer.WriteLine("\x1B" + "*b16V" + "\x08" + "\xFF" + "\x08" + "\x00" + "\x08" + "\x00" + "\x08" + "\x00" + "\x08" + "\xFF" + "\x08" + "\x00" + "\x08" + "\xff" + "\x08" + "\xff");
            //magenta data
            writer.WriteLine("\x1B" + "*b16V" + "\x08" + "\x00" + "\x08" + "\xFF" + "\x08" + "\x00" + "\x08" + "\x00" + "\x08" + "\xff" + "\x08" + "\xff" + "\x08" + "\x00" + "\x08" + "\xff");
            //yellow data
            writer.WriteLine("\x1B" + "*b16W" + "\x08" + "\x00" + "\x08" + "\x00" + "\x08" + "\xff" + "\x08" + "\x00" + "\x08" + "\xff" + "\x08" + "\xff" + "\x08" + "\xff" + "\x08" + "\x00");

            //end raster
            writer.WriteLine("\x1B" + "*rC");
            writer.WriteLine("\x1B" + "E");
            writer.Close();
            File.Copy(path, "LPT3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Print())
                MessageBox.Show("Nie udalo sie");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintRaster();     
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            string path = @".\image.png";
            System.Drawing.Image img = System.Drawing.Image.FromFile(path);
            Point location = new Point(100, 100);
            e.Graphics.DrawImage(img, location);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            var printDocument = new PrintDocument();
            printDocument.PrintPage += printDocument1_PrintPage;
            printDocument.Print();
        }

    }
}
