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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using ComboBox = System.Windows.Forms.ComboBox;



namespace IS_YONETIMI_YAZILIMI
{
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter dr;

        void HammaddeMalzemeYedekParca()
        {
            con = new SqlConnection("Data Source=ELA\\SQLEXPRESS;Initial Catalog=\"KULLANICI GIRISI\";Integrated Security=True");
            con.Open();
            dr = new SqlDataAdapter("SELECT *FROM HammaddeMalzemeYedekParca", con);
            DataTable tablo = new DataTable();
            dr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();

        }


        public Form4()
        {
            InitializeComponent();
            linkLabel1.Text = "Zorunlu alan ! ";
            linkLabel2.Text = "Zorunlu alan ! ";
            linkLabel3.Text = "Zorunlu alan !";
            linkLabel4.Text = "Zorunlu alan ! ";
            linkLabel5.Text = "Zorunlu alan ! ";
            linkLabel6.Text = "Zorunlu alan ! ";
            linkLabel7.Text = "Zorunlu alan ! ";
            linkLabel8.Text = "Zorunlu alan ! ";
            linkLabel9.Text = "Zorunlu alan ! ";
            



            textBox1.TextChanged += TextBox_TextChanged;
            


            textBox1.Leave += textBox_Leave;
            


            comboBox1.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox4.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox5.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox6.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox7.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox8.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox9.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox1.Leave += ComboBox_Leave;
            comboBox2.Leave += ComboBox_Leave;
            comboBox3.Leave += ComboBox_Leave;
            comboBox4.Leave += ComboBox_Leave;
            comboBox5.Leave += ComboBox_Leave;
            comboBox6.Leave += ComboBox_Leave;
            comboBox7.Leave += ComboBox_Leave;
            comboBox8.Leave += ComboBox_Leave;
            comboBox9.Leave += ComboBox_Leave;



        }
        

        private void Form4_Load(object sender, EventArgs e)
        {
            HammaddeMalzemeYedekParca();
            linkLabel1.Visible = false;



        }
        
        private void GuncelleUyari(Control control)
        {
            if (control == null)
                return;
            // TextBox ve ilgili LinkLabel eşleştirmesi
            var kontrolListesi = new Dictionary<Control, LinkLabel>
            {
                { comboBox1, linkLabel1 },
                { comboBox2, linkLabel2 },
                { textBox1,  linkLabel3 },
                { comboBox4, linkLabel4 },
                { comboBox5, linkLabel5 },
                { comboBox6, linkLabel6 },
                { comboBox7, linkLabel7 },
                { comboBox8, linkLabel8 },
                { comboBox3, linkLabel9 },
                

            };


            // Eğer textBox kontrol listesinde varsa
            if (kontrolListesi.TryGetValue(control, out LinkLabel linkLabel))
            {
                if (control is TextBox textBox)
                {
                    linkLabel.Visible = string.IsNullOrWhiteSpace(textBox.Text);
                }
                else if (control is ComboBox comboBox)
                {
                    linkLabel.Visible = comboBox.SelectedIndex == -1; // Seçim yapılmamışsa
                }
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("TextBox değişti!");
            if (sender is Control control)
            {
                GuncelleUyari(control); // Her iki durumda da GuncelleUyari metodunu çağır
            }
        }

        // TextBox'tan çıkıldığında da kontrol et
        private void textBox_Leave(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                GuncelleUyari(control); // Her iki durumda da GuncelleUyari metodunu çağır
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                GuncelleUyari(comboBox); // ComboBox değiştiğinde de kontrol et
            }
        }
        private void ComboBox_Leave(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                GuncelleUyari(comboBox); // ComboBox'tan çıkıldığında kontrol et
            }
        }





        

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO HammaddeMalzemeYedekParca (MalzemeTipi, MalzemeSinifi, StokKodu , StokYeri, MaximumStok, MinimumStok, YenidenSiparisNoktasi,KDVOrani, SatinAlmaBirimi , İkincilBirim, Aciklama) VALUES (@MalzemeTipi,@MalzemeSinifi,@StokKodu,@StokYeri,@MaximumStok,@MinimumStok,@YenidenSiparisNoktasi,@KDVOrani,@SatinAlmaBirimi,@İkincilBirim,@Aciklama)";
            //string sorgu = "INSERT INTO dbo.CariKart(Adi, Aciklama, Adres, PostaKodu, Sehir, FirmaTelNo1, FirmaTelNo2, UlkeKodu, IBAN)VALUES(@Adi, @Aciklama, @Adres, @PostaKodu, @Sehir, @FirmaTelNo1, @FirmaTelNo2, @UlkeKodu, @IBAN)";



            com = new SqlCommand(sorgu, con);



            com.Parameters.AddWithValue("@MalzemeTipi", comboBox1.Text);
            com.Parameters.AddWithValue("@MalzemeSinifi", comboBox2.Text);
            com.Parameters.AddWithValue("@StokKodu", textBox1.Text);
            com.Parameters.AddWithValue("@StokYeri", comboBox4.Text);
            com.Parameters.AddWithValue("@MaximumStok", comboBox5.Text);
            com.Parameters.AddWithValue("@MinimumStok", comboBox6.Text);
            com.Parameters.AddWithValue("@YenidenSiparisNoktasi", comboBox7.Text);
            com.Parameters.AddWithValue("@KDVOrani", comboBox8.Text);
            com.Parameters.AddWithValue("@SatinAlmaBirimi", comboBox3.Text);
            com.Parameters.AddWithValue("@İkincilBirim", comboBox9.Text);
            com.Parameters.AddWithValue("@Aciklama", textBox2.Text);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            HammaddeMalzemeYedekParca();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM HammaddeMalzemeYedekParca WHERE Aciklama = @Aciklama";
            com = new SqlCommand(sorgu, con);
            com.Parameters.AddWithValue("@Aciklama", textBox2.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            HammaddeMalzemeYedekParca();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string secilenMetin = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string secilenMetin = comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string secilenMetin = comboBox3.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenMetin = comboBox4.Text;
        }

        private void comboBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string secilenMetin = comboBox5.Text;
        }

        private void comboBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string secilenMetin = comboBox6.Text;
        }

        private void comboBox7_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string secilenMetin = comboBox7.Text;
        }

        private void comboBox8_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string secilenMetin = comboBox8.Text;
        }

        private void comboBox9_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string secilenMetin = comboBox9.Text;
        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox3.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox4.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox5.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox6.SelectedItem = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox7.SelectedItem = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox8.SelectedItem = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox9.SelectedItem = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE HammaddeMalzemeYedekParca SET MalzemeSinifi=@MalzemeSinifi ,StokKodu=@StokKodu ,StokYeri=@StokYeri,MaximumStok=@MaximumStok,MinimumStok=@MinimumStok,YenidenSiparisNoktasi=@YenidenSiparisNoktasi, KDVOrani=@KDVOrani,SatinAlmaBirimi=@SatinAlmaBirimi ,İkincilBirim=@İkincilBirim," +
                "Aciklama=@Aciklama WHERE  MalzemeTipi=@MalzemeTipi ";
            com = new SqlCommand(sorgu, con);




            com.Parameters.AddWithValue("@MalzemeTipi", comboBox1.Text);
            com.Parameters.AddWithValue("@MalzemeSinifi", comboBox2.Text);
            com.Parameters.AddWithValue("@StokKodu", textBox1.Text);
            com.Parameters.AddWithValue("@StokYeri", comboBox4.Text);
            com.Parameters.AddWithValue("@MaximumStok", comboBox5.Text);
            com.Parameters.AddWithValue("@MinimumStok", comboBox6.Text);
            com.Parameters.AddWithValue("@YenidenSiparisNoktasi", comboBox7.Text);
            com.Parameters.AddWithValue("@KDVOrani", comboBox8.Text);
            com.Parameters.AddWithValue("@SatinAlmaBirimi", comboBox3.Text);
            com.Parameters.AddWithValue("@İkincilBirim", comboBox9.Text);
            com.Parameters.AddWithValue("@Aciklama", textBox2.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            HammaddeMalzemeYedekParca();
        }
    }






}

