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
    /// Interaction logic for Masowki.xaml
    /// </summary>
    public partial class Masowe : Window
    {
        Masowki masowka = new Masowki();
        public Masowe()
        {
            InitializeComponent();
        }
        private void ButtonDodajZasob_Click(object sender, RoutedEventArgs e)
        {
            if (NazwaZasobu.Text.Length != 0 && IloscZasobu.Text.Length != 0 && CenaJednZasobu.Text.Length != 0)
            {
                Zasob zasob = new Zasob();
                zasob.Nazwa = NazwaZasobu.Text;
                zasob.Ilosc = Convert.ToDouble(IloscZasobu.Text);
                try {
                    zasob.CenaJedn = Convert.ToDouble(CenaJednZasobu.Text.Replace('.', ','));
                }catch(FormatException) {
                    MessageBox.Show("Musisz podac poprana wartosc ceny!");
                }

                this.ListaZasobow.ItemsSource = masowka.Zasoby;
                this.ListaZasobow.DataContext = masowka.Zasoby;
            }
        }

        private void ButtonObliczKoszt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
