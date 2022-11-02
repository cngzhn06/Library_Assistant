using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KutuphaneAsistani
{
    public partial class KayitOl : Form
    {
        public KayitOl()
        {
            InitializeComponent();
            label2.Text = Captcha();
            textBox1.Focus();
        }
        public string Captcha()
        {
            string captcha;
            //BüyükHarfler, KüçükHarfler ve semboller için dizilerimi oluşturdum.
            string[] BuyukHarfler = { "A", "B", "C", "Ç", "D", "E", "F", "G", "Ğ", "H",
                "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z" };
            string[] KucukHarfler = { "a", "b", "c", "ç", "d", "e", "f", "g", "ğ", "h", "ı", "i", "j",
                "k", "l", "m", "n", "o", "ö", "p", "r", "s", "ş", "t", "u", "ü", "v", "y", "z" };
            
            //Random classından rnd nesnemi türettim.
            Random rnd = new Random();

            //dizilerde kaçıncı elemanı ekleyeceğimi belirlemek için değişken tanımlıyorum.
            int sembol1, sembol2, sembol3, sembol4, sembol5;

            //Rakamlar için olan haricinde diğer dizilerde 0. indeksten dizinin uzunluğuna bağlı olan dizi indeks rakamına kadar rastgele değer üretiyorum. Rakamlar için 0 ile10 arasında rakam üretilmesini istiyorum. 
            sembol1 = rnd.Next(0, BuyukHarfler.Length);
            sembol2 = rnd.Next(0, 10);
            sembol3 = rnd.Next(0, KucukHarfler.Length);
            sembol5 = rnd.Next(0, BuyukHarfler.Length);
            captcha = BuyukHarfler[sembol1] + sembol2.ToString() + KucukHarfler[sembol3] +  BuyukHarfler[sembol5];
            return captcha;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void KayitOl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void KayitOl_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            label2.Text = Captcha();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string kullaniciadi;
            string sifre;
            if (textBox4.Text==label2.Text && textBox3.Text==textBox2.Text)
            {
                SqlBaglanti bgln = new SqlBaglanti();
                SqlCommand command = new SqlCommand("Insert into  kutuphaneUsers (username,password,re_password) values ('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "')",bgln.baglanti());
                command.ExecuteNonQuery();
                MessageBox.Show("BAŞARIYLA KAYIT OLDUNUZ","06 KÜTÜPHANE",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                GirisPanel giris = new GirisPanel();
                giris.Show();

            }
            else
            {
                MessageBox.Show("BİLGİLERİ TEKRAR KONTROL EDİN", "06 KÜTÜPHANE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Captcha();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
