using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace otopark_otomasyonu
{
    public partial class araçkaydı : Form
    {
        public araçkaydı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HJIVJQ7;Initial Catalog=arac_otopark;Integrated Security=True");

        private void araçkaydı_Load(object sender, EventArgs e)
        {
            Boşaraçlar();
            Marka();

        }

        private void Marka()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select marka from markabilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combomarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void Boşaraçlar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from araçdurumu WHERE durumu='BOŞ'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboparkyeri.Items.Add(read["parkyeri"].ToString());
            }
            baglanti.Close();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex regexmail = new Regex(@"^([a-zA-Z0-9]+)(@(gmail|hotmail).com)$");
            Regex regextel = new Regex(@"^(5[0-9]{9})");
            Regex regextc = new Regex(@"^([1-9]{1})([0-9]{10})");
            Regex regexisim = new Regex(@"([a-zA-Z]{2,})");
            Regex regexsoyisim = new Regex(@"([a-zA-Z]{2,})");


            bool isValidmail = regexmail.IsMatch(txtemail.Text);
            bool isValidtel = regextel.IsMatch(txttelefon.Text);
            bool isValidtc = regextc.IsMatch(txtTC.Text);
            bool isValidisim = regexisim.IsMatch(txtad.Text);
            bool isValidsoyisim = regexsoyisim.IsMatch(txtsoyad.Text);

            if (!isValidtc)
            {
                MessageBox.Show("Lütfen TC numaranızı kontrol ediniz.");
            }

            else if (!isValidisim)
            {
                MessageBox.Show("Lütfen adınızı kontrol ediniz");
            }
            else if (!isValidsoyisim)
            {
                MessageBox.Show("Lütfen soyadınızı kontrol ediniz.");
            }
           
            else if (!isValidtel)
            {
                MessageBox.Show("Lütfen geçerli bir telefon numarası giriniz.");
            }
            else if (!isValidmail)
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz.");
            }


            else
            {

                baglanti.Open();

                SqlCommand komut = new SqlCommand("insert into araçkaydı(Tc,Ad,Soyad,Telefon,Email,Plaka,Marka,Seri,Renk,Parkyeri,Tarih) values('"+txtTC.Text.ToString()+ "','" + txtad.Text.ToString() + "','" + txtsoyad.Text.ToString() + "','" + txttelefon.Text.ToString() + "','" + txtemail.Text.ToString() + "','" + txtplaka.Text.ToString() + "','" + combomarka.Text.ToString() + "','" + txtseri.Text.ToString() + "','" + txtrenk.Text.ToString() + "','" + comboparkyeri.Text.ToString() + "','"+ DateTime.Now.ToString()+"')", baglanti);

                

                komut.ExecuteNonQuery();

                SqlCommand komut2 = new SqlCommand("update araçdurumu set durumu='DOLU' WHERE parkyeri='" + comboparkyeri.SelectedItem + "'", baglanti);

                komut2.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Araç kaydı oluşturuldu", "Kayıt");
            }
            comboparkyeri.Items.Clear();
            Boşaraçlar();
            combomarka.Items.Clear();
            Marka();
            


            foreach (Control item in groupkişi.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

            foreach (Control item in grouparaç.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }

            foreach (Control item in grouparaç.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }

        }

       

       
      

        private void btnmarka_Click_1(object sender, EventArgs e)
        {
            Marka marka = new Marka();
            marka.ShowDialog();
        }

        

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}