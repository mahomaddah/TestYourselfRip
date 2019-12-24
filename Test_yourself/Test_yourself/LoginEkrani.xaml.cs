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

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBx.Text.ToLower() == "admin" && PasswordTextBx.Password == "1234567")
            {
                MessageBox.Show("Adminim");
                // admin girisi
                // new admin panel
            }
            else if (OgretmenCheckbx.IsChecked==true ){
                if (UsernameTextBx.Text != "" && PasswordTextBx.Password != "")
                {
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
