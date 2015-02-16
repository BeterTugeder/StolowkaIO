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
        private void odswiez()
        {
            /*StolowkaDS ds = new StolowkaDS();
            StolowkaDSTableAdapters.UzytkownicyTableAdapter ad = new StolowkaDSTableAdapters.UzytkownicyTableAdapter();

            ad.Fill(ds.Uzytkownicy);

            ds.Uzytkownicy.Columns.Remove("haslo");*/

            Uzytkownik u = new Uzytkownik();

            System.Data.DataTable dt = u.lista();

            dt.Columns.Remove("haslo");

            gridView.AutoGenerateColumns = true;

            //Console.WriteLine(dt.Rows[0]["uzytkownik_id"]);

            gridView.ItemsSource = dt.DefaultView;

            //B_usun_urz.Click += B_usun_urz_Click;

        }

        void B_usun_urz_Click(object sender, RoutedEventArgs e)
        {
            if (gridView.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano użytkownika.");
                return;
            }
            else
            {
                Uzytkownik u = (Uzytkownik)gridView.SelectedItem;
                MessageBox.Show("Jesteś pewien, że chcesz usunąć użytkownika"+u.Imie+" "+ u.Nazwisko + "?","ciongi",MessageBoxButton.YesNo);
            }
        }
        public Uzytkownicy()
        {
            InitializeComponent();
            odswiez();
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
                    odswiez();
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
