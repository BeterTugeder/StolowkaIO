﻿using System;
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
            Logowanie r = new Logowanie(true);
            r.Show();
            this.Close();
            //InitializeComponent();
            
        }

        private void zaloguj(object sender, RoutedEventArgs e)
        {
            Uzytkownik log = new Uzytkownik();
            log.Login = login.Text;
            bool typ = log.logowanie(pass.Password);
            if (log.Zalogowany == true)
            {
<<<<<<< HEAD
                MessageBox.Show("Zalogowano");
=======
>>>>>>> 7602c466891ea2cd23ff7dc4e9ed63a83a0e72f1
                Logowanie r = new Logowanie(typ);
                r.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Błędny login lub hasło");
            }
        }

        private void zamknij(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
