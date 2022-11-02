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
    public partial class GirisPanel : Form
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source=CENGIZHAN\\SQLEXPRESS; Initial Catalog=master; Integrated Security=TRUE");
        public GirisPanel()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            KayitOl kayit = new KayitOl();
            kayit.Show();

        }
        bool isThere;
        private void button2_Click(object sender, EventArgs e)
        {
            String kullaniciadi = textBox1.Text;
            String sifre = textBox2.Text;
            int userId = 0;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from kutuphaneUsers", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                if (kullaniciadi == reader["username"].ToString() && sifre == reader["password"].ToString())
                {
                    isThere = true;
                    userId = Convert.ToInt32(reader["ID"].ToString());
                    break;
                }
                else
                {
                    isThere = false;
                }
            }
            baglanti.Close();
            if (isThere == true)
            {
                this.Hide();
                AnaSayfa anasayfa = new AnaSayfa(userId);
                anasayfa.Show();

            }
            else
            {
                MessageBox.Show("Hatalı giriş !", "Program");
            }



            //string kullaniciadi = textBox1.Text;
            //string sifre = textBox2.Text;
            //SqlBaglanti bgln = new SqlBaglanti();
            //SqlCommand command = new SqlCommand("Select *from kutuphaneUsers", bgln.baglanti());
            //SqlDataReader reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    if (kullaniciadi == reader["username"].ToString() && sifre == reader["re_password"].ToString())
            //    {
            //        this.Hide();
            //        AnaSayfa anasayfa = new AnaSayfa();
            //        anasayfa.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("BİLGİLERİ TEKRAR KONTROL EDİN", "06 KÜTÜPHANE", MessageBoxButtons.OK, MessageBoxIcon.Error);


            //}
            //if (kullaniciadi == reader["username"].ToString() && sifre == reader["password"].ToString())
            //{
            //    this.Hide();
            //    AnaSayfa anasayfa = new AnaSayfa();
            //    anasayfa.Show();
            //}
            //else
            //{
            //    MessageBox.Show("BİLGİLERİ TEKRAR KONTROL EDİN", "06 KÜTÜPHANE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }


    }

