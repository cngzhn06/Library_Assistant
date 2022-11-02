using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using KutuphaneAsistani;
using System.Collections;
using System.Windows.Forms;

namespace BookModel
{
    class BooksModel
    {

        public int id;
        public string book_name;
        public string publisher;
        public string type;
        public string author;
        
        public BooksModel(int id,string book_name,string publisher,string type,string author) {
            this.id = id;
            this.book_name=book_name;
            this.publisher = publisher;
            this.type = type;
            this.author = author;
        }

        public static bool addBook(BooksModel book)
        {
            SqlBaglanti sql = new SqlBaglanti();
            SqlCommand command = new SqlCommand("Insert into KutuphaneBookList (book_name, author,publisher,type) values ('" + book.book_name +
                "', '" + book.author + "', '" + book.publisher + "','" + book.type + "')", sql.baglanti());
            int sonuc = command.ExecuteNonQuery();
          if (sonuc != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }
        public static bool delBook(BooksModel book)
        {
            SqlBaglanti sql = new SqlBaglanti();
            SqlCommand command = new SqlCommand("DELETE FROM kutuphaneBookList WHERE ID="+book.id+ "", sql.baglanti());
            int sonuc = command.ExecuteNonQuery();
            if (sonuc != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool upBook() // GÜNCELLE BUTONU
        {
             SqlBaglanti sql = new SqlBaglanti();
             SqlCommand command = new SqlCommand("UPDATE kutuphaneBookList set author='" + author + "',publisher='" + publisher + "',type='" + type + "' where book_name='" + book_name + "'", sql.baglanti());
             int sonuc = command.ExecuteNonQuery();
             if (sonuc != 0)
             {
                 return true;
             }
             else
             {
                 return false;
             }

        }
    }
}
