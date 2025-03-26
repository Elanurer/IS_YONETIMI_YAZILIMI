using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace IS_YONETIMI_YAZILIMI
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ELA\\SQLEXPRESS;Initial Catalog=\"KULLANICI GIRISI\";Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //KULLANICI GİRİŞİ 
            /*
            string kullanıcıadı = textBox1.Text;
            string sifre = textBox2.Text;
            SqlCommand com = new SqlCommand("Select*From GirisEkrani1 where KullaniciAdi = @p1 And Sifre = @p2", con);
            con.Open();
            com.Parameters.AddWithValue("@p1", textBox1.Text);
            com.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                Form form2= new Form2();
                form2.Show();
            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Girdiğiniz bilgiler eksik ya da hatalıdır.\n Lütfen tekrar deneyiniz .", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalıdır", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            con.Close();
            */
            this.Hide();
            Form2 form22 = new Form2();
            form22.Show();
        }
    }
}
