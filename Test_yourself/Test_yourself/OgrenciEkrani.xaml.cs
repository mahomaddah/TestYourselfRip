﻿using System;
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
using System.Data.SqlClient;
using System.Windows.Threading;

namespace Test_yourself
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {

        Ogretmen Ogretmen;
        Ders ders;
        Soru soru;
        private int time = 1800;//20 soru 1.5 er dk
        private DispatcherTimer timer;
        private int oAnSoru;

        public MainWindow()
        {
            Ogretmen = new Ogretmen();
            ders = new Ders();
            ders.soruHavuzu = new List<Soru>();
            SqlConnection conn = new SqlConnection("Server=MAHOLAPTOP\\SQLEXPRESS;Database=TestYourselfDB;Integrated Security=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Soru]", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                soru = new Soru();
                soru.SoruMetni = reader.GetString(1);
                soru.Cevap = reader.GetString(2);
                soru.SoruKonusu = reader.GetString(3);
                ders.soruHavuzu.Add(soru);

            }
            reader.Close();
            conn.Close();
            LoginControl();         
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
            LabelSoru.Height = 211;
            // zaman basla
            timer.Start();
            SinavOlmak();
            DuzSayfaGetir();
            SoruHazirlan(0);

        }
        private void SoruHazirlan(int i)
        {
            LabelSoru.Content = ders.soruHavuzu.ElementAt(i).SoruMetni;
        }

        private void SinavLarimBtn_Click(object sender, RoutedEventArgs e)
        {
            SinavOlmamak();
            LabelSoru.Height = 480;
            LabelSoru.Visibility = Visibility.Visible;
            LabelSoru.Content = "gecmis sinavlariniz : 1. sinaviniz : 240 aldim 20 s de\n2. 300 aldim 20 dk da";//ogrenci.GecmisSinavSoncLarMesajlari.listele foretch te 
            timer.Stop();
            DuzSayfaGetir();
        }

        private void CikisYapBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new LoginEkrani().ShowDialog();
        }

        public int j = 1;
        private void NextSoruBtn_Click(object sender, RoutedEventArgs e)
        { j++;
            SoruHazirlan(j);
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

        private void LoginControl()
        {
            if (LoginEkrani.kullanici == 2)
            {
                //ogrenciyim
            }
            else if (LoginEkrani.kullanici == 1)
            {
                //adminim
                
                
            }
            else
            {
                //hocayim
                
            }                                          
        }

        private void DerslerimBTN_Click(object sender, RoutedEventArgs e)
        {         
            
        }

        private void ProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginEkrani.kullanici == 1)
            {
                /// derslerimi goruntule...
            }
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
