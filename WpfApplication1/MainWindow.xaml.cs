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

namespace Stolowka
{
    /// <summary>
    /// Interaction logic for Logowanie.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void zaloguj(object sender, RoutedEventArgs e)
        {
            Uzytkownik log = new Uzytkownik();
            log.Login = login.Text;
            log.logowanie(pass.Password);
            /*
             * WYWALIC MOZLIWOSC LOGOWANIA Z HASLEM I LOGINEM ADMIN ADMIN
             * */
            if (log.Zalogowany == true || (login.Text == "admin" && pass.Password == "admin") )
            {
                MessageBox.Show("Zalogowano");
                Logowanie r = new Logowanie();
                r.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Błędny login lub hasło");
            }
        }
    }
}
