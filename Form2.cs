using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaMotoSiklet
{
    public partial class Form2 : Form
    {
        MotoSiklet java = new MotoSiklet();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            java.DepoKapasite = 5000;
            java.YakitMiktari = java.DepoKapasite;

            progressBar2.Maximum = java.YakitMiktari;
            progressBar2.Value = progressBar2.Maximum;

            java.AsiriSicakOldu += Java_AsiriSicakOldu; // +=den sonra tab tuşuna bas.
        }

        public void Java_AsiriSicakOldu(int sicaklik)
        {
            this.Text = sicaklik.ToString() + " AŞIRI SICAK";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (java.Durumu==false)
            {
                java.Durumu = true;
                button1.Text = "Durdur";
                timer1.Enabled = true;
            }
            else
            {
                java.Durumu = false;
                button1.Text = "Çalıştır.";
                timer1.Enabled = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            java.GucVer(); // her bir snde bir yakıtı hesaplayıp tüketecek.
            progressBar2.Value = java.YakitMiktari;
            progressBar1.Value = java.Hiz;

            if (java.Durumu==false)
            {
                java.Hiz = 0;
                timer1.Enabled = false;
                button1.Text = "Çalıştır.";
            }
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            java.Guc = trackBar1.Value;
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            java.Vites = trackBar2.Value;
        }
    }
}
