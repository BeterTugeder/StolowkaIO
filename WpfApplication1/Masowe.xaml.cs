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
        public Masowe()
        {
            InitializeComponent();
            Masowki masowka = new Masowki();
        }

        private void ButtonDodajZasob_Click(object sender, RoutedEventArgs e)
        {
            if (NazwaZasobu.Text.Length != 0 && IloscZasobu.Text.Length != 0 && CenaJednZasobu.Text.Length != 0)
            {
                Zasob zasob = new Zasob();
                zasob.Nazwa = NazwaZasobu.Text;
                zasob.Ilosc = Convert.ToDouble(IloscZasobu.Text);
                zasob.CenaJedn = Convert.ToDouble(CenaJednZasobu.Text);
            }
        }

        private void ButtonObliczKoszt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
