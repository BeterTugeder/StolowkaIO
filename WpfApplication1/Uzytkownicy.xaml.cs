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
    /// Interaction logic for Uzytkownicy.xaml
    /// </summary>
    public partial class Uzytkownicy : Window
    {
        private void odswierz()
        {
            StolowkaDS ds = new StolowkaDS();
            StolowkaDSTableAdapters.UzytkownicyTableAdapter ad = new StolowkaDSTableAdapters.UzytkownicyTableAdapter();

            ad.Fill(ds.Uzytkownicy);

            gridView.DataContext = ds.Uzytkownicy.DefaultView;
        }
        public Uzytkownicy()
        {
            InitializeComponent();
            odswierz();
        }

        private void ButtonDodawanieUzytkownikow_Click(object sender, RoutedEventArgs e)
        {
            if (ImieUzytkownika.Text.Length != 0 && NazwiskoUzytkownika.Text.Length != 0 && LoginUzytkownika.Text.Length != 0 && HasloUzytkownika.Password.Length != 0)
            {
                Uzytkownik user = new Uzytkownik();
                user.Imie = ImieUzytkownika.Text;
                user.Nazwisko = NazwiskoUzytkownika.Text;
                user.Login = LoginUzytkownika.Text;
                if ((bool)dupa.IsChecked)
                {
                    user.Typ = true;
                }
                else if ((bool)dupadupa.IsChecked)
                {
                    user.Typ = false;
                }
                if (user.Istnieje())
                {
                    MessageBox.Show("Użytkownik o podanym loginie istnieje.");
                }
                else
                {
                    user.dodawanie(HasloUzytkownika.Password);
                    MessageBox.Show("Pomyślnie dodano użytkownika.");
                    odswierz();
                }
            }
            else
            {
                MessageBox.Show("Wypełni wszystkie pola przed dodaniem użytkownika.");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
