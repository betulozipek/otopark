using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otopark_otomasyonu
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        System.Data.SqlClient.SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-HJIVJQ7;Initial Catalog=arac_otopark;Integrated Security=True");
        DataSet daset = new DataSet();
        private void Form5_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from araçkaydı", baglanti);
            adtr.Fill(daset, "form5");
            dataGridView1.DataSource = daset.Tables["form5"];
            baglanti.Close();
        }
    }
}
