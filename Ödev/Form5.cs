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
    public partial class Form5 : Form
    {
        Bitmap kaynak, islem;
        
        public Form5()
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
                    int s1, s2, s3, min, max;
                    s1 = renk.R;
                    s2 = renk.G;
                    s3 = renk.B;
                    min = 0;
                    max = 0;
                    if (s1 >= s2 && s1 >= s3)
                    {
                        max = s1;
                    }
                    else if (s2 >= s1 && s2 >= s3)
                    {

                        max = s2;
                    }
                    else if (s3 >= s2 && s3 >= s1)
                    {

                        max = s3;
                    }
                    if (s1 <= s2 && s1 <= s3)
                    {
                        min = s1;
                    }
                    else if (s2 <= s1 && s2 <= s3)
                    {
                        min = s2;

                    }
                    else if (s3 <= s2 && s3 <= s1)
                    {
                        min = s3;
                    }
                    int acıklık = (min + max) / 2;
                    Color gri = Color.FromArgb(acıklık, acıklık, acıklık);
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
