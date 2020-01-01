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
    /// LoginEkrani.xaml etkileşim mantığı
    /// </summary>
    public partial class LoginEkrani : Window
    {
        public LoginEkrani()
        {
            InitializeComponent();
        }
        public static short kullanici { get; set; }//1=admin 2=ogrenci 3= ogretmen

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBx.Text.ToLower() == "admin" && PasswordTextBx.Password == "1234567")
            {
                kullanici = 1;
                MessageBox.Show("Adminim");
                new MainWindow().ShowDialog();
                // admin girisi
                // new admin panel
                
            }
            else if (OgretmenCheckbx.IsChecked==true ){
                if (UsernameTextBx.Text != "" && PasswordTextBx.Password != "")
                {
                    kullanici = 3;
                    MessageBox.Show("Ogretmenim");
                    this.Hide();
                    new MainWindow().ShowDialog();
                    // new teacher panel
                    // data base e baglanip 
                    
                }
                else
                {
                    MessageBox.Show("Lutfen Sifrenizi ve adinizi dogru girdginizdan emin olunuz...");
                }
            }
            else
            {
                if (UsernameTextBx.Text != "" && PasswordTextBx.Password != "")
                {
                    kullanici = 2;
                    this.Hide();
                    new MainWindow().ShowDialog();
                    // new student panel
                    // data base e baglanip 
                    
                }
                else
                {
                    MessageBox.Show("Lutfen Sifrenizi ve adinizi dogru girdginizdan emin olunuz...");
                }
            }           
            
        }
    }
}
