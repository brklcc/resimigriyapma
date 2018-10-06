using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ödev
{
    public partial class Form2 : Form
    {
        Bitmap kaynak, islem;
        public Form2()
        {
            InitializeComponent();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void anaMenüToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void bT709AlgoritmasıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gen = kaynak.Width;
            int yuk = kaynak.Height;
            islem = new Bitmap(gen, yuk);
            for (int y = 0; y < yuk; y++)
            {
                for (int x = 0; x < gen; x++)
                {
                    Color renk = kaynak.GetPixel(x, y);

                    double ortalama = (renk.R * 0.2125 + renk.G * 0.7154 + renk.B * 0.072);
                    degertut.Text = Math.Ceiling(ortalama).ToString();
                    int rt709 = Convert.ToInt32(degertut.Text);
                    Color gri = Color.FromArgb(rt709, rt709, rt709);
                    islem.SetPixel(x, y, gri);
                }
            }
            pictureBox2.Image = islem;
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = openFileDialog1.ShowDialog();
            if(sonuc==DialogResult.OK)
            {
                kaynak = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = kaynak;
            }
        }
    }
}
