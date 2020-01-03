using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Test_yourself
{
    /// <summary>
    /// OgretmenFormu.xaml etkileşim mantığı
    /// </summary>
    public partial class OgretmenFormu : Window
    {
        private bool dersEkleAc=false;
        Ogretmen Ogretmen;
        public Ders ders;
        Soru soru;
        List<Soru> deneme;
        public OgretmenFormu()
        {
            InitializeComponent();
            Ogretmen = new Ogretmen();
            ders = new Ders();
            
            At();
            deneme= new List<Soru>(); // 1 . unit testi icin ders.soruHavuzu dan mi sorun ? hayir degil mis 
            ders.soruHavuzu = new List<Soru>();
            Ogretmen.Dersler = new List<Ders>();
            SqlConnection conn = new SqlConnection("Server=MAHOLAPTOP\\SQLEXPRESS;Database=TestYourselfDB;Integrated Security=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Soru]", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) // 2. unit testi icin data base tan mi yanlis cekiyor verileri ? for de gosterdim degilmis 
            {
                soru = new Soru(); // 3. unit testi soru nesne nin olus masiyla bir sroun var dir ozamn her biri icin ayri olsmayi deneyelim :sonuc hata cozuldu ...
                soru.SoruMetni = reader.GetString(1);
                soru.Cevap = reader.GetString(2);
                soru.SoruKonusu = reader.GetString(3);
                ders.soruHavuzu.Add(soru);
                              
            }
            reader.Close();
            conn.Close();
           // Ogretmen.Dersler.Add(ders);

            ///data base tan aktar ... user name gore 
        }


        private void GridBarraTittle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void CikisYapBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new LoginEkrani().ShowDialog();
        }
        
        private void DersEkle_Click(object sender, RoutedEventArgs e)
        {
            
            if(dersEkleAc == false)
            {
                DersEkleIsim.Visibility = Visibility.Visible;
                dersEkleAc = true;
            }
            else
            {
                ///ders ekle
                DersEkleIsim.Visibility = Visibility.Hidden;
                dersEkleAc = false;
                DersEkleIsim.Text = "Ders ismi girin..";
            }
        }

        private void DerslerimBTN_Click(object sender, RoutedEventArgs e)
        {
            derslerimi();
        }
      
        private void OgretmenOnayBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DersEkleIsim_MouseEnter(object sender, MouseEventArgs e)
        {
            DersEkleIsim.Text = "";
        }
        private void At()
        {
            ders.dersinKonulari = new List<string>();
            ders.DersIsmi = "Matematik";
            ders.DersinHocasi = "Ahmet";
            ders.dersinKonulari.Add("carpim");
            ders.dersinKonulari.Add("toplam");
        }

        private void ListViewum_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
      

        private void DersListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DersListView.Visibility = Visibility.Hidden;
            ListViewum.Visibility = Visibility.Visible;
            ListViewum.ItemsSource = ders.soruHavuzu;
        }
        private void derslerimi()
        {
            List<dersvio> DersIsmi = new List<dersvio>();
            dersvio dersvio = new dersvio();
            dersvio.DersIsmi = "Matematik";
            DersIsmi.Add(dersvio);
            DersListView.ItemsSource = DersIsmi;
        }
    }
    
}
