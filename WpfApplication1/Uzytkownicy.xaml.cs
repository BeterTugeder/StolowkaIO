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
            Uzytkownik u = new Uzytkownik();

            System.Data.DataTable dt = u.lista();

            dt.Columns.Remove("haslo");

            gridView.AutoGenerateColumns = true;

            gridView.ItemsSource = dt.DefaultView;

            B_usun_uz.Click += B_usun_uz_Click;
        }

        void B_usun_uz_Click(object sender, RoutedEventArgs e)
        {
            object item = gridView.SelectedItem;
            if (gridView.SelectedItem == null || (gridView.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text == "")
            {
                MessageBox.Show("Nie wybrano użytkownika.");
                return;
            }
            else
            {
                string ID = (gridView.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                MessageBoxResult result = MessageBox.Show("Jesteś pewien, że chcesz usunąć użytkownika " + (gridView.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text + " " + (gridView.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text + "?", "Usuwanie użytkownika", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Uzytkownik u = new Uzytkownik();
                    u.Id = Convert.ToInt32((gridView.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                    u.usuwanie();
                    MessageBox.Show("Usunięto użytkownika.");
                    odswiez();
                }
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
        void B_usun_uz_Click1(object sender, RoutedEventArgs e) { }
    }
}