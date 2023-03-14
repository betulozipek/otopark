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
namespace otopark_otomasyonu
{
    public partial class Satis : Form
    {
        public Satis()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HJIVJQ7;Initial Catalog=arac_otopark;Integrated Security=True");
        DataSet daset = new DataSet();

        private void satış_Load(object sender, EventArgs e)
        {
            Satislarilistele();
            Hesapla();
            
        }

        private void Hesapla()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(tutar) from satis", baglanti);
            label1.Text = "Toplam Tutar =" + komut.ExecuteScalar() + "TL";
          
          
            baglanti.Close();
        }

        private void Satislarilistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from satis", baglanti);
            adtr.Fill(daset, "satis");
            dataGridView1.DataSource = daset.Tables["satis"];
            baglanti.Close();
        }
        

        
    }
}
