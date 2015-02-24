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
        Masowki masowka;
        public Masowe()
        {
            InitializeComponent();
            masowka =  new Masowki();
        }
        public void odswiez_grid()
        {
            this.ListaZasobow.ItemsSource = null;
            this.ListaZasobow.ItemsSource = masowka.Zasoby;
            this.ListaZasobow.DataContext = masowka.Zasoby;
        }
        private void ButtonDodajZasob_Click(object sender, RoutedEventArgs e)
        {
            if (NazwaZasobu.Text.Length != 0 && IloscZasobu.Text.Length != 0 && CenaJednZasobu.Text.Length != 0)
            {
                Zasob zasob = new Zasob();
                zasob.Nazwa = NazwaZasobu.Text;
                
                try 
                {
                    zasob.CenaJedn = Convert.ToDouble(CenaJednZasobu.Text.Replace('.', ','));
                    try
                    {
                        zasob.Ilosc = Convert.ToDouble(IloscZasobu.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Musisz podać popraną ilość!");
                        return;
                    }
                }
                catch(FormatException)
                {
                    MessageBox.Show("Musisz podać popraną wartość ceny!");
                    return;
                }
                try
                {
                    masowka.Zasoby.Add(zasob);
                    odswiez_grid();
                }
                catch
                {
                    MessageBox.Show("Błąd danych.");
                    return;
                }
                
            }
        }

        private void ButtonObliczKoszt_Click(object sender, RoutedEventArgs e)
        {
            double czas, godzina, suma;
            try
            {
                czas = Convert.ToDouble(CzasTrwania.Text.Replace('.', ','));
                try
                {
                    godzina = Convert.ToDouble(Za_godzine.Text.Replace('.', ','));
                    try
                    {
                        suma = masowka.LiczKoszt() + czas * godzina;
                        KosztCalkowity.Text = Convert.ToString(suma) + " PLN";
                    }
                    catch
                    {
                        MessageBox.Show("Błąd danych.");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Błędny koszt za godzine.");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Błędny czas trwania.");
                return;
            }
        }

        private void ButtonUsunZasob_Click(object sender, RoutedEventArgs e)
        {
            Zasob zasob;
            try
            {
                zasob = (Zasob)this.ListaZasobow.SelectedItem;
                try
                {
                    masowka.Zasoby.Remove(zasob);
                    odswiez_grid();
                }
                catch
                {
                    MessageBox.Show("Błąd danych");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Wybierz zasób.");
                return;
            }  
        }

    }
}
