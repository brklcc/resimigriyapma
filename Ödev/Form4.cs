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
    public partial class Form4 : Form
    {
        Bitmap kaynak, islem;
        public Form4()
        {
            InitializeComponent();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

                    double ort = (renk.R * 0.3 + renk.G * 0.59 + renk.B * 0.11);
                    degertut.Text = Math.Ceiling(ort).ToString();
                    int luma = Convert.ToInt32(degertut.Text);
                    Color gri = Color.FromArgb(luma, luma, luma);
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
                kaynak = new Bitmap (openFileDialog1.FileName);
                pictureBox1.Image = kaynak;

            }
        }
    }
}
