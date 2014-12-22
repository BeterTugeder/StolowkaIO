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

namespace Stolowka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Logi tmp = new Logi();
            tmp.TypOperacji = "Dodawanie użytkownika";
            tmp.Uzytkownik = new Uzytkownik();
            tmp.Uzytkownik.Id = 0;
            tmp.DataOperacji = DateTime.Now;
            try
            {
                tmp.dodawanie();
                tmp.wyswietlanie();
            }
            catch (Exception ex)
            {
                komm.Text = ex.Message;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Logi tmp = new Logi();
            komm.Text = "";
            foreach (StolowkaDS.LogiRow r in tmp.wyswietlanie())
            {
                komm.Text += r.Operacja;
            }
        }
    }
}
