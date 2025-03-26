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


namespace IS_YONETIMI_YAZILIMI
{
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter dr;

        void CariKart()
        {
            con = new SqlConnection("Data Source=ELA\\SQLEXPRESS;Initial Catalog=\"KULLANICI GIRISI\";Integrated Security=True");
            con.Open();
            dr = new SqlDataAdapter("SELECT *FROM CariKart", con);
            DataTable tablo = new DataTable();
            dr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();

        }
        

        public Form3()
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
            linkLabel10.Text = "Zorunlu alan ! ";
            linkLabel11.Text = "Zorunlu alan ! ";


            // Sadece belirli TextBox'lara KeyPress olayını bağla
            textBox1.KeyPress += textBox_KeyPress;
            textBox4.KeyPress += textBox_KeyPress;
            textBox7.KeyPress += textBox_KeyPress;
            textBox8.KeyPress += textBox_KeyPress;
            textBox5.KeyPress += textBox_KeyPress;
            textBox11.KeyPress += textBox_KeyPress;
            textBox14.KeyPress += textBox_KeyPress;
            textBox17.KeyPress += textBox_KeyPress;

            textBox1.TextChanged += TextBox_TextChanged;
            textBox3.TextChanged += TextBox_TextChanged;
            textBox4.TextChanged += TextBox_TextChanged;
            textBox5.TextChanged += TextBox_TextChanged;
            textBox6.TextChanged += TextBox_TextChanged;
            textBox7.TextChanged += TextBox_TextChanged;
            textBox8.TextChanged += TextBox_TextChanged;
            textBox9.TextChanged += TextBox_TextChanged;


            textBox1.Leave += textBox_Leave;
            textBox3.Leave += textBox_Leave;
            textBox4.Leave += textBox_Leave;
            textBox5.Leave += textBox_Leave;
            textBox6.Leave += textBox_Leave;
            textBox7.Leave += textBox_Leave;
            textBox8.Leave += textBox_Leave;
            textBox9.Leave += textBox_Leave;
            

            comboBox1.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox1.Leave += ComboBox_Leave;
            comboBox2.Leave += ComboBox_Leave;
            comboBox3.Leave += ComboBox_Leave;
        }

        private void Verileriyenile()
        {

            string connectionString = "Data Source=ELA\\SQLEXPRESS;Initial Catalog=\"KULLANICI GIRISI\";Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter dr = new SqlDataAdapter("SELECT * FROM CariKart", con);
                DataTable tablo = new DataTable();
                dr.Fill(tablo);
                BindingSource bs = new BindingSource();
                bs.DataSource = tablo;
                dataGridView1.DataSource = bs;
                bs.ResetBindings(false);
                bs.DataSource = tablo;
                //DataGridView1.Data
            }

        }
        

        
        private int count = 0;
        

        



        private void GuncelleUyari(Control control)
        {

            // TextBox ve ilgili LinkLabel eşleştirmesi
            var kontrolListesi = new Dictionary<Control, LinkLabel>
            {
                { textBox1, linkLabel1 },
                { textBox2, linkLabel2 },
                { textBox4, linkLabel6 },
                { textBox6, linkLabel5 },
                { textBox8, linkLabel3 },
                { comboBox1, linkLabel4 }
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

        // Tüm TextBox'lar değiştiğinde çalışacak
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
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



        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakam ve kontrol tuşlarına izin ver
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Geçersiz tuşu engelle
            }
        }

        

        

        

        

        

        

        private void Form3_Load_1(object sender, EventArgs e)
        {
            CariKart();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = false;

            }
            else
            {
                checkBox2.Enabled = true;
            }

            linkLabel1.Text = "Zorunlu alan ! ";
            linkLabel2.Text = "Zorunlu alan ! ";
            label2.Text = "Müşteri Kodu ;";
            label4.Text = "Müşteri Adı ;";
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            linkLabel1.Visible = true;
            linkLabel2.Visible = true;

            if (!checkBox1.Checked)
            {
                
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                linkLabel1.Visible = false;
                linkLabel2.Visible = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
            }


            label2.Text = "Tedarikçi Kodu ;";
            label4.Text = "Tedarikçi Adı ;";
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            linkLabel1.Visible = true;
            linkLabel2.Visible = true;


            if (!checkBox2.Checked)
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                linkLabel1.Visible = false;
                linkLabel2.Visible = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            button5.Enabled = true;

            if (count == 1) // Maksimum 2 kez ekleme izni
            {
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = true;
                textBox15.Visible = true;

            }
            else if (count == 2)
            {
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                textBox16.Visible = true;
                textBox17.Visible = true;
                textBox18.Visible = true;

                button1.Enabled = false;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE CariKart SET   Kod=@Kod , Adi=@Adi ,Aciklama=@Aciklama ,Adres=@Adres,PostaKodu=@PostaKodu,Sehir=@Sehir,FirmaTelNo1=@FirmaTelNo1, FirmaTelNo2=@FirmaTelNo2,AdSoyad=@AdSoyad ,TelNo=@TelNo,EMail=@EMail,BankaAdi=@BankaAdi,UlkeKodu=@UlkeKodu,IBAN=@IBAN WHERE KartTuru=@KartTuru";
            com = new SqlCommand(sorgu, con);

            string kartTuru = "Belirsiz"; // Varsayılan değer

            if (checkBox1.Checked)
            {
                kartTuru = "Müşteri";
            }

            else if (checkBox2.Checked)
            {
                kartTuru = "Tedarikçi";
            }
            linkLabel1.Visible = false;
            linkLabel2.Visible = false;


            com.Parameters.AddWithValue("@KartTuru", kartTuru);

            com.Parameters.AddWithValue("@Kod", textBox1.Text);
            com.Parameters.AddWithValue("@Adi", textBox2.Text);
            com.Parameters.AddWithValue("@Aciklama", textBox3.Text);
            com.Parameters.AddWithValue("@Adres", textBox4.Text);
            com.Parameters.AddWithValue("@PostaKodu", textBox6.Text);
            com.Parameters.AddWithValue("@Sehir", Convert.ToString(comboBox1.SelectedValue));
            com.Parameters.AddWithValue("@FirmaTelNo1", textBox8.Text);
            com.Parameters.AddWithValue("@FirmaTelNo2", textBox7.Text);
            com.Parameters.AddWithValue("@AdSoyad", textBox11.Text);
            com.Parameters.AddWithValue("@TelNo", textBox10.Text);
            com.Parameters.AddWithValue("@EMail", textBox13.Text);
            com.Parameters.AddWithValue("@BankaAdi", Convert.ToString(comboBox3.SelectedValue));
            com.Parameters.AddWithValue("@UlkeKodu", Convert.ToString(comboBox2.SelectedValue));
            com.Parameters.AddWithValue("@IBAN", textBox16.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            CariKart();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM CariKart WHERE Kod = @Kod ";
            com = new SqlCommand(sorgu, con);
            com.Parameters.AddWithValue("@Kod", textBox1.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            CariKart();
        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "Tedarikçi")
            {
                checkBox2.Checked = true;
                checkBox1.Checked = false;
                label2.Text = "Tedarikçi Kodu ;";
                label3.Text = "Tedarikçi Adı ;";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                linkLabel1.Visible = true;
                linkLabel2.Visible = true;
            }
            else if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "Müşteri")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
                linkLabel1.Text = "Zorunlu alan ! ";
                linkLabel2.Text = "Zorunlu alan ! ";
                label2.Text = "Müşteri Kodu ;";
                label3.Text = "Müşteri Adı ;";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                linkLabel1.Visible = true;
                linkLabel2.Visible = true;




            }
            linkLabel1.Visible = false;
            linkLabel2.Visible = false;

            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            comboBox3.SelectedItem = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox16.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO CariKart (KartTuru,Kod,Adi,Aciklama,Adres,PostaKodu,Sehir,FirmaTelNo1,FirmaTelNo2,AdSoyad,TelNo,EMail,BankaAdi,UlkeKodu,IBAN) VALUES (@KartTuru,@Kod,@Adi,@Aciklama,@Adres,@PostaKodu,@Sehir,@FirmaTelNo1,@FirmaTelNo2,@AdSoyad,@TelNo,@EMail,@BankaAdi,@UlkeKodu,@IBAN)";


            com = new SqlCommand(sorgu, con);

            string kartTuru = "Belirsiz"; // Varsayılan değer

            if (checkBox1.Checked)
            {
                kartTuru = "Müşteri";
            }

            else if (checkBox2.Checked)
            {
                kartTuru = "Tedarikçi";
            }

            com.Parameters.AddWithValue("@KartTuru", kartTuru);
            com.Parameters.AddWithValue("@Kod", textBox1.Text);
            com.Parameters.AddWithValue("@Adi", textBox2.Text);
            com.Parameters.AddWithValue("@Aciklama", textBox3.Text);
            com.Parameters.AddWithValue("@Adres", textBox4.Text);
            com.Parameters.AddWithValue("@PostaKodu", textBox6.Text);
            com.Parameters.AddWithValue("@Sehir", Convert.ToString(comboBox1.SelectedValue));
            com.Parameters.AddWithValue("@FirmaTelNo1", textBox8.Text);
            com.Parameters.AddWithValue("@FirmaTelNo2", textBox7.Text);
            com.Parameters.AddWithValue("@AdSoyad", textBox11.Text);
            com.Parameters.AddWithValue("@TelNo", textBox10.Text);
            com.Parameters.AddWithValue("@EMail", textBox13.Text);
            com.Parameters.AddWithValue("@BankaAdi", Convert.ToString(comboBox3.SelectedValue));
            com.Parameters.AddWithValue("@UlkeKodu", Convert.ToString(comboBox2.SelectedValue));
            com.Parameters.AddWithValue("@IBAN", textBox16.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            CariKart();

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            // IBAN uzunluğunu kontrol et (Türkiye için 26 karakter)
            if (textBox4.Text.Length > 24)
            {
                textBox4.Text = textBox16.Text.Substring(0, 24); // Maksimum uzunluk
                textBox4.SelectionStart = textBox16.Text.Length; // İmleci sona taşı
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            count--;
            button1.Enabled = true;

            if (count == 1) // Maksimum 2 kez ekleme izni
            {


                label24.Visible = false;
                label20.Visible = false;
                label19.Visible = false;
                textBox18.Visible = false;
                textBox17.Visible = false;
                textBox15.Visible = false;
            }
            else if (count == 0)
            {

                label17.Visible = false;
                label18.Visible = false;
                label15.Visible = false;
                textBox14.Visible = false;
                textBox12.Visible = false;
                textBox5.Visible = false;
                label24.Visible = false;
                label20.Visible = false;
                label19.Visible = false;
                textBox18.Visible = false;
                textBox17.Visible = false;
                textBox15.Visible = false;

                button5.Enabled = false;
            }
        }
    }

}

