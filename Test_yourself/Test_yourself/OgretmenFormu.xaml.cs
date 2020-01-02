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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Test_yourself
{
    /// <summary>
    /// OgretmenFormu.xaml etkileşim mantığı
    /// </summary>
    public partial class OgretmenFormu : Window
    {
        Ogretmen Ogretmen;
        Ders ders;
        Soru soru;
        public OgretmenFormu()
        {
            InitializeComponent();
            Ogretmen = new Ogretmen();
            ders = new Ders();
            soru = new Soru();
            soru.SoruKonusu = "test";
            soru.SoruMetni = "beyaz kutu mu yoksa siyah kutu mu kullanici tarafindan yapilabilir ?";
            soru.Cevap = "beyaz kutu";
            ders.soruHavuzu = new List<Soru>();
            Ogretmen.Dersler = new List<Ders>();
            ders.soruHavuzu.Add(soru);
            Ogretmen.Dersler.Add(ders);
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

        }

        private void DerslerimBTN_Click(object sender, RoutedEventArgs e)
        {

        }


        private void OgretmenOnayBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
