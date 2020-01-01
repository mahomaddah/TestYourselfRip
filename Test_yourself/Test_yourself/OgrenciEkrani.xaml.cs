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
using System.Windows.Threading;

namespace Test_yourself
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        private int time = 1800;//20 soru 1.5 er dk
        private DispatcherTimer timer;
        private int oAnSoru;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_tick;
            Consumo consumo = new Consumo();
            DataContext = new ConsumoViewModel(consumo);
            SinavOlmamak();


        }
        private void SinavOlmamak()
        {
            TimeText.Visibility = Visibility.Hidden;
            NextSoruBtn.Visibility = Visibility.Hidden;
            LabelSoru.Visibility = Visibility.Hidden;
            AwnserTextBx.Visibility = Visibility.Hidden;
        }
        private void SinavOlmak()
        {
            TimeText.Visibility = Visibility.Visible;
            NextSoruBtn.Visibility = Visibility.Visible;
            LabelSoru.Visibility = Visibility.Visible;
            AwnserTextBx.Visibility = Visibility.Visible;
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                TimeText.Content = string.Format("{0}:{1}", time / 60, time % 60);
            }
            else
            {
                timer.Stop();
                MessageBox.Show("zaman Bitti");// sinav bitme senariyosu 
            }
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
            timer.Start();
            SinavOlmak();
            DuzSayfaGetir();
            
           

        }

        private void SinavLarimBtn_Click(object sender, RoutedEventArgs e)
        {
            SinavOlmamak();
            timer.Stop();
            DuzSayfaGetir();
        }

        private void CikisYapBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new LoginEkrani().ShowDialog();
        }
        

        private void NextSoruBtn_Click(object sender, RoutedEventArgs e)
        {
            //yeni soru ()...
            oAnSoru++;
            if (oAnSoru == 20)
            {
                NextSoruBtn.Content = "Sınavı Sonlandır";
            }
            if (oAnSoru==21)
            {                
                oAnSoru = 0;
                MessageBox.Show("Basarilar sorulari "+ TimeText.Content.ToString() + " surede bitirdiniz ... Sonuc :");
                timer.Stop();
            }//sorularbitti ise
        }

        private void AwnserTextBx_MouseEnter(object sender, MouseEventArgs e)
        {
            AwnserTextBx.Text = "";
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
