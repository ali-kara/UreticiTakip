using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;

namespace Bardkde
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        List<string> list = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            pad_an_int(9999, 4);

        }

        private void pad_an_int(int N, int numberToFill)
        {
            for (int i = 0; i < 999; i++)
            {
                list.Add(i.ToString().PadLeft(4, '0'));
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            changeBarcode(textBox1.Text);
        }

        Random r = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            string Final = textBox1.Text = "FLORA-1-" + list[r.Next(0, list.Count - 1)];

            changeBarcode(Final);

        }

        private void changeBarcode(string s)
        {
            var barcode = BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = barcode.Draw(s, 50);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
    }
}
