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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test_yourself
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Consumo consumo = new Consumo();
            DataContext = new ConsumoViewModel(consumo);
            TimeText.Visibility = Visibility.Hidden;

        }     

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridBarraTittle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void IstaBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new MainWindow().ShowDialog();           
        }
        private void DuzSayfaGetir()
        {
            HataSayisiGosterici.Visibility = Visibility.Hidden;
            SoruCoamusGosterici.Visibility = Visibility.Hidden;
            DersCalismaGosterici.Visibility = Visibility.Hidden;
            HataOraniGosterici.Visibility = Visibility.Hidden;
            BorderG1.Margin = new Thickness(-114, -222, -114, 0);
            BorderG2.Visibility = Visibility.Hidden;
        }
        private void SinavOlBtn_Click(object sender, RoutedEventArgs e)
        {
            // zaman basla
            TimeText.Visibility = Visibility.Visible;
            DuzSayfaGetir();

        }

        private void SinavLarimBtn_Click(object sender, RoutedEventArgs e)
        {
            TimeText.Visibility = Visibility.Hidden;
            DuzSayfaGetir();
        }

        private void CikisYapBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new LoginEkrani().ShowDialog();
        }
    }


    internal class ConsumoViewModel
    {
        public List<Consumo> Consumo { get; private set; }

        public ConsumoViewModel(Consumo consumo)
        {
            Consumo = new List<Consumo>();
            Consumo.Add(consumo);
        }
    }

    internal class Consumo
    {
        public string tittle { get; private set; }
        public int Yuzdesi { get; private set; }

        public Consumo()
        {
            tittle = "Bütün Zamanların";
            Yuzdesi = YuzdeHesapla();
        }

        private int YuzdeHesapla()
        {
            return 47; //yuzdesini hesaplar
        }
    }
}
