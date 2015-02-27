using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
    public partial class Logowanie : Window
    {
        bool typ;
        StolowkaDS ds;
        StolowkaDSTableAdapters.RaportTableAdapter adR;

        StolowkaDSTableAdapters.Raport_potrawyTableAdapter adRP;
        StolowkaDSTableAdapters.PotrawyTableAdapter adP;

        StolowkaDSTableAdapters.Raport_osobyTableAdapter adRO;
        StolowkaDSTableAdapters.Osoby_korzystajaceTableAdapter adOK;

        public Logowanie(bool typ)
        {
            InitializeComponent();
            this.typ = typ;
            this.ds = new StolowkaDS();
            adR = new StolowkaDSTableAdapters.RaportTableAdapter();

            adRP = new StolowkaDSTableAdapters.Raport_potrawyTableAdapter();
            adP = new StolowkaDSTableAdapters.PotrawyTableAdapter();

            adRO = new StolowkaDSTableAdapters.Raport_osobyTableAdapter();
            adOK = new StolowkaDSTableAdapters.Osoby_korzystajaceTableAdapter();

            Data.Text = DateTime.Today.Date.ToString();
            ButtonImportuj.Click += ButtonImportuj_Click;
        }
        DateTime date;

        public bool istnieje(DateTime d)
        {
            adR.Fill(ds.Raport);
            DataRow[] dr = ds.Raport.Select("data = '" + d + "'");
            if (dr.Length > 0)
                return true;
            else
                return false;
        }

        public void uaktualnij_w_bazie(string[] tab, int[] tab1, DateTime data)
        {
            try
            {
                int s = 0, o = 4, k = 8;
                int w = 0, p = 3 ,i = 6;
                string nazwa = "";
                adR.Fill(ds.Raport);
                adRP.Fill(ds.Raport_potrawy);
                adP.Fill(ds.Potrawy);
                adRO.Fill(ds.Raport_osoby);
                adOK.Fill(ds.Osoby_korzystajace);

                DataRow drR = ds.Raport.Select("data = '" + data + "'").First();
                DataRow[] drRP = ds.Raport_potrawy.Select("raport_id = '" + drR[0] + "'");
                DataRow[] drRO = ds.Raport_osoby.Select("raport_id = '" + drR[0] + "'");
                foreach (DataRow r in drRP)
                {
                    DataRow rP = ds.Potrawy.Select("potrawa_id = '" + r[0] + "'").First();
                    switch (Convert.ToInt16(rP[2]))
                    {
                        case 0:
                            nazwa = tab[s++];
                            break;
                        case 1:
                            nazwa = tab[o++];
                            break;
                        case 2:
                            nazwa = tab[k++];
                            break;
                    }
                    rP[1] = nazwa;
                    adP.Update(rP);
                }
                adP.Fill(ds.Potrawy);

                foreach (DataRow r in drRO)
                {
                    DataRow rOK = ds.Osoby_korzystajace.Select("osoby_id = '" + r[1]+ "'").First();
                    switch (rOK[1].ToString())
                    {
                        case "Wychowankow":
                            rOK[2] = tab1[w++];
                            break;
                        case "Personelu":
                            rOK[2] = tab1[p++];
                            break;
                        case "Innych":
                            rOK[2] = tab1[i++];
                            break;
                    }
                    adOK.Update(rOK);
                }
                adOK.Fill(ds.Osoby_korzystajace);
                MessageBox.Show("Uaktaulniono dane.");
            }
            catch
            {
                MessageBox.Show("Bład uaktualniania bazy.");
            }


        }


        public void dodaj_do_bazy(string[] tab, int[] tab1, DateTime data)
        {
            try
            {
                adR.Insert(data);
                adR.Fill(ds.Raport);
                adRP.Fill(ds.Raport_potrawy);
                adP.Fill(ds.Potrawy);
                adRO.Fill(ds.Raport_osoby);
                adOK.Fill(ds.Osoby_korzystajace);
                string nazwa;
                byte typ;
                int rR = ds.Raport.Max(x => x.raport_id);
                int rP, rOK;
                for (int i = 0; i < 12; i++)
                {
                    typ = 0;
                    if (i <= 7 && i > 3)
                        typ = 1;
                    else if (i <= 11 && i > 7)
                        typ = 2;
                    adP.Insert(tab[i], typ);
                    adP.Fill(ds.Potrawy);
                    rP = ds.Potrawy.Max(y => y.potrawa_id);
                    adRP.Insert(rP, rR);
                    
                }
                for (int j = 0; j < 9; j++)
                {
                    nazwa = "Wychowankow";
                    if (j >= 3 && j < 6)
                        nazwa = "Personelu";
                    else if (j >= 6)
                        nazwa = "Innych";
                    adOK.Insert(nazwa, tab1[j]);
                    adOK.Fill(ds.Osoby_korzystajace);
                    rOK = ds.Osoby_korzystajace.Max(z => z.osoby_id);
                    adRO.Insert(rR, rOK);
                    

                }
                    adRP.Fill(ds.Raport_potrawy);
                    adRO.Fill(ds.Raport_osoby);
                    MessageBox.Show("Pomyślnie dodano do bazy.");
            }
            catch
            {
                MessageBox.Show("Błąd dodawania do bazy.");
            }
         
        }
        private void Calendar_SelectedDatesChanged(object sender,
        SelectionChangedEventArgs e)
        {
            if (kalendarz.SelectedDate.HasValue)
            {
                this.date = kalendarz.SelectedDate.Value;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void sniadanieWychow_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonUzytkownicy_Click(object sender, RoutedEventArgs e)
        {
            if (typ == true)
            {
                Window ownedWindow = new Uzytkownicy();
                ownedWindow.Owner = this;
                ownedWindow.Show();
            }
            else
            {
                MessageBox.Show("Przykro mi, nie masz uprawnień administratora.");
            }
            
        }

        private void ButtonImportuj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                date = Convert.ToDateTime(kalendarz.SelectedDate.ToString());
                if (!this.istnieje(date))
                {
                    MessageBox.Show("W tym dniu nie dodano nic do bazy.");
                    return;
                }

                Data.Text = date.ToShortDateString();
                adR.Fill(ds.Raport);
                adRP.Fill(ds.Raport_potrawy);
                adP.Fill(ds.Potrawy);
                adRO.Fill(ds.Raport_osoby);
                adOK.Fill(ds.Osoby_korzystajace);

                DataRow drR = ds.Raport.Select("data = '" + date + "'").First();

                DataRow[] drRP = ds.Raport_potrawy.Select("raport_id = '" + drR[0] + "'");
                DataRow[] drRO = ds.Raport_osoby.Select("raport_id = '" + drR[0] + "'");

                string[] tab = new string[12];
                int[] tab1 = new int[9];
                int s = 0, o = 4, k = 8;
                int w = 0, pe = 3, i = 6;

                foreach (DataRow r in drRP)
                {
                    DataRow p = ds.Potrawy.Select("potrawa_id = '" + r[0] + "'").First();
                    switch (Convert.ToInt16(p[2]))
                    {
                        case 0:
                            tab[s++] = p[1].ToString();
                            break;
                        case 1:
                            tab[o++] = p[1].ToString();
                            break;
                        case 2:
                            tab[k++] = p[1].ToString();
                            break;
                    }
                }

                Sniadanie1.Text = tab[0];
                Sniadanie2.Text = tab[1];
                Sniadanie3.Text = tab[2];
                Sniadanie4.Text = tab[3];
                Obiad1.Text = tab[4];
                Obiad2.Text = tab[5];
                Obiad3.Text = tab[6];
                Obiad4.Text = tab[7];
                Kolacja1.Text = tab[8];
                Kolacja2.Text = tab[9];
                Kolacja3.Text = tab[10];
                Kolacja4.Text = tab[11];
                foreach (DataRow r in drRO)
                {
                    DataRow os = ds.Osoby_korzystajace.Select("osoby_id = '" + r[1] + "'").First();
                    switch (os[1].ToString())
                    {
                        case "Wychowankow":
                            tab1[w++] = Convert.ToInt32(os[2]);
                            break;
                        case "Personelu":
                            tab1[pe++] = Convert.ToInt32(os[2]);
                            break;
                        case "Innych":
                            tab1[i++] = Convert.ToInt32(os[2]);
                            break;
                    }

                }

                sniadanieWychow.Text = tab1[0].ToString();
                obiadWychow.Text = tab1[1].ToString();
                kolacjaWychow.Text = tab1[2].ToString();
                sniadaniePersonel.Text = tab1[3].ToString();
                obiadPersonel.Text = tab1[4].ToString();
                kolacjaPersonel.Text = tab1[5].ToString();
                sniadanieInni.Text = tab1[6].ToString();
                obiadInni.Text = tab1[7].ToString();
                kolacjaInni.Text = tab1[8].ToString();

                sniadanieSuma.Text = (tab1[0] + tab1[3] + tab1[6]).ToString();
                obiadSuma.Text = (tab1[1] + tab1[4] + tab1[7]).ToString();
                kolacjaSuma.Text = (tab1[2] + tab1[5] + tab1[8]).ToString();

            }
            catch
            {
                MessageBox.Show("Błąd importu z bazy danych.");
            }
        }

        private void ButtonMasowki_Click(object sender, RoutedEventArgs e)
        {
            Window ownedWindow = new Masowe();
            ownedWindow.Owner = this;
            ownedWindow.Show();
        }

        private void ButtonWyloguj_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void zapisz(object sender, RoutedEventArgs e)
        {
            string[] tab = new string[12];
            int[] tab1 = new int[9];
            DateTime data;
            try
            {   
                tab[0] = Sniadanie1.Text.ToString();
                tab[1] = Sniadanie2.Text.ToString();
                tab[2] = Sniadanie3.Text.ToString();
                tab[3] = Sniadanie4.Text.ToString();
                tab[4] = Obiad1.Text.ToString();
                tab[5] = Obiad2.Text.ToString();
                tab[6] = Obiad3.Text.ToString();
                tab[7] = Obiad4.Text.ToString();
                tab[8] = Kolacja1.Text.ToString();
                tab[9] = Kolacja2.Text.ToString();
                tab[10] = Kolacja3.Text.ToString();
                tab[11] = Kolacja4.Text.ToString();

                if (sniadanieWychow.Text == "")
                    tab1[0] = 0;
                else tab1[0] = Convert.ToInt32(sniadanieWychow.Text.ToString());
                if (obiadWychow.Text == "")
                    tab1[1] = 0;
                else tab1[1] = Convert.ToInt32(obiadWychow.Text.ToString());
                if (kolacjaWychow.Text == "")
                    tab1[2] = 0;
                else tab1[2] = Convert.ToInt32(kolacjaWychow.Text.ToString());

                if (sniadaniePersonel.Text == "")
                    tab1[3] = 0;
                else tab1[3] = Convert.ToInt32(sniadaniePersonel.Text.ToString());
                if (obiadPersonel.Text == "")
                    tab1[4] = 0;
                else tab1[4] = Convert.ToInt32(obiadPersonel.Text.ToString());
                if (kolacjaPersonel.Text == "")
                    tab1[5] = 0;
                else tab1[5] = Convert.ToInt32(kolacjaPersonel.Text.ToString());

                if (sniadanieInni.Text == "")
                    tab1[6] = 0;
                else tab1[6] = Convert.ToInt32(sniadanieInni.Text.ToString());
                if (obiadInni.Text == "")
                    tab1[7] = 0;
                else tab1[7] = Convert.ToInt32(obiadInni.Text.ToString());
                if (kolacjaInni.Text == "")
                    tab1[8] = 0;
                else tab1[8] = Convert.ToInt32(kolacjaInni.Text.ToString());

                data = Convert.ToDateTime(kalendarz.SelectedDate.ToString());
                switch (data.CompareTo(DateTime.Today))
                {
                    case 1:
                        MessageBox.Show("Wybrana data jest późniejsza od obecnej.");
                        break;
                    default:
                        if (!istnieje(data))
                            dodaj_do_bazy(tab, tab1, data);
                        else
                            uaktualnij_w_bazie(tab, tab1, data);
                        break;
                }

            }
            catch
            {
                MessageBox.Show("Zły format danych lub nie wybrano daty.");
                return;
            }
        }

        private void ButtonImportuj_Click_1(object sender, RoutedEventArgs e)
        {

        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
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
            }*/
    }

    //http://www.microsoft.com/en-us/download/details.aspx?id=14839

    /*private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Logi tmp = new Logi();
        komm.Text = "";
        foreach (StolowkaDS.LogiRow r in tmp.wyswietlanie())
        {
            komm.Text += r.Operacja;
        }*/
    //d:\Dropbox\IO\Projekt\StolowkaIO\WpfApplication1\WDOW.DBF
    //D:\Dropbox\IO\Projekt\StolowkaIO\WpfApplication1\WDOW.DBF
    /* string pth = sciezka.Text;
     try
     {
         string connStr = @"Provider=vfpoledb;Data Source=" + pth.Substring(0, pth.LastIndexOf("\\")) + ";Collating Sequence=machine;";
         OleDbConnection conn = new OleDbConnection(connStr);
         conn.Open();

         string cmd_string = "select * from " + pth.Substring(0, pth.LastIndexOf("."));
         OleDbDataAdapter da = new OleDbDataAdapter(cmd_string, conn);
         DataSet ds = new DataSet();
         da.Fill(ds);

         DataTable dt = ds.Tables[0];

         komm.Text = "";
         foreach (DataRow dr in dt.AsEnumerable())
         {
             komm.Text += dr[5] + "\n";
         }
     }
     catch (Exception ex)
     {
         komm.Text = pth + "\n" + ex.Message;
<<<<<<< HEAD
     }
            
=======
     }*/
    /*
>>>>>>> 756068b6994e0cac9e941c59a1ab2bf7b0bdbf05
        string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ofdDBF.FileName.Substring(0, ofdDBF.FileName.LastIndexOf("\\")) + ";Extended Properties=dBASE IV;"; 
 
        OleDbConnection conn = new OleDbConnection(connStr); 
        conn.Open(); 
 
        string cmd_string = "select * from " + ofdDBF.SafeFileName.Substring(0, ofdDBF.SafeFileName.IndexOf(".")); 
        MessageBox.Show(cmd_string); 
        OleDbDataAdapter da = new OleDbDataAdapter(cmd_string, conn); 
        DataSet ds = new DataSet(); 
        da.Fill(ds); 
        dgvImport.DataSource = ds.Tables[0]; 
<<<<<<< HEAD
      */
    //=======

    /*
    Uzytkownik u = new Uzytkownik();
    u.Login = "admin";
    u.logowanie("admin");
    Console.WriteLine( u.Zalogowany.ToString() );

    Uzytkownik uu = new Uzytkownik();
    uu.Login = "test";
    uu.Imie = "Testowy";
    uu.Nazwisko = "Tesotwe";
    uu.Typ = false;
    uu.dodawanie("testowe haslo");

    uzytkownicy.ItemsSource = uu.lista().AsDataView();
>>>>>>> 756068b6994e0cac9e941c59a1ab2bf7b0bdbf05
}*/

    //}
}
