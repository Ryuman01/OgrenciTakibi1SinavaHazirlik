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

namespace OgrenciTakibi1
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=tsomtal.com;Initial Catalog=UyeDb206;Integrated Security=True; ");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'uyeDb206DataSet.uyeler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.uyelerTableAdapter.Fill(this.uyeDb206DataSet.uyeler);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sqlcumle = "INSERT INTO uyeler (KullaniciAdi,Ad_Soyad,E_Posta,Sifre) VALUES ('" + txtK_Adi.Text + "','" + txtAd_Soyad.Text + "','" + txtPosta.Text+ "','" + txtSifre.Text + "');";
                SqlCommand cmd = new SqlCommand(sqlcumle,baglanti);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Veriler başarı ile kaydedildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası\n" + ex.Message);
            }
            finally
            {
                if (baglanti != null) baglanti.Close();
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }
    }
}
