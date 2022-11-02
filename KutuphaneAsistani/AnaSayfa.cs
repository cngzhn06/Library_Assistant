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
using System.Collections;
using BookModel;
using Kutuphane_Helper;
namespace KutuphaneAsistani
{
    public partial class AnaSayfa : Form
    {
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        int userId;
        public AnaSayfa(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            fillTable();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void fillTable()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            SqlBaglanti sql = new SqlBaglanti();
            SqlConnection con = sql.baglanti();

            String query = "Select * from kutuphaneBookList order by ID ASC"; 
            SqlCommand command = new SqlCommand(query, con);
           
            SqlDataReader reader = command.ExecuteReader();
            ArrayList array = new ArrayList();
            int tempOrder = 0;
            while (reader.Read())
            {
    
                array.Add(new BooksModel(Convert.ToInt32(reader["ID"].ToString()), reader["book_name"].ToString(), reader["publisher"].ToString(), reader["type"].ToString(), reader["author"].ToString()));
            }
            string[] tag = new string[] { "#","ID", "Kitap Adı", "Yayıncı", "Kategori", "Yazar" };
            //fill datatable columns Name
            Helper helper = new Helper();
            var dt = helper.SetColumnsHeaderName(tag);
            //connect db and fetch table name

            foreach (BooksModel item in array)
            {
                tempOrder += 1;
                dt.Rows.Add(new Object[] {tempOrder, item.id, item.book_name,item.publisher,item.type,item.author });
        
            }
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;



            //Formumuzdaki DataGridViewin veri kaynağını oluşturduğumuz tablo olarak gösteriyoruz.
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BooksModel book = new BooksModel(0, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            if (BooksModel.addBook(book))
            {
                MessageBox.Show("BAŞARILI", "06 KÜTÜPHANE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("BAŞARISIZ", "06 KÜTÜPHANE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
       
            fillTable();
        }

        private void AnaSayfa_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void AnaSayfa_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SATIR SEÇİP SİLME
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            //}
            //else
            //{
            //    MessageBox.Show("Lüffen silinecek satırı seçin.");
            //}

            BooksModel book = new BooksModel(Convert.ToInt32(textBox5.Text), "", "", "", "");
            if (BooksModel.delBook(book))
            {
                MessageBox.Show("BAŞARILI", "06 KÜTÜPHANE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("BAŞARISIZ", "06 KÜTÜPHANE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            fillTable();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {

        }

       

        private void button3_Click_1(object sender, EventArgs e)
        {
            BooksModel book = new BooksModel(0, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
             if (book.upBook())
            {
                MessageBox.Show("BAŞARILI", "06 KÜTÜPHANE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("BAŞARISIZ", "06 KÜTÜPHANE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            fillTable();

        }
    }
}
