﻿using System;
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
        public Logowanie()
        {
            InitializeComponent();
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
            Window ownedWindow = new Uzytkownicy();
            ownedWindow.Owner = this;
            ownedWindow.Show();
        }

        private void ButtonMasowki_Click(object sender, RoutedEventArgs e)
        {
            Window ownedWindow = new Masowe();
            ownedWindow.Owner = this;
            ownedWindow.Show();
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
    //<<<<<<< HEAD
    /* string pth = sciezka.Text;
=======
     /*string pth = sciezka.Text;
>>>>>>> 756068b6994e0cac9e941c59a1ab2bf7b0bdbf05
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
