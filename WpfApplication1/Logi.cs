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
    class Logi
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string typOperacji;

        public string TypOperacji
        {
            get { return typOperacji; }
            set { typOperacji = value; }
        }

        DateTime dataOperacji;

        public DateTime DataOperacji
        {
            get { return dataOperacji; }
            set { dataOperacji = value; }
        }

        Uzytkownik uzytkownik;

        internal Uzytkownik Uzytkownik
        {
            get { return uzytkownik; }
            set { uzytkownik = value; }
        }

        /**
         * Dodawanie nowego wpisu na bazie danych z atrybutów klasy do bazy danych
         * */
        public void dodawanie()
        {
            StolowkaDS DS = new StolowkaDS();
            StolowkaDSTableAdapters.LogiTableAdapter a = new StolowkaDSTableAdapters.LogiTableAdapter();
            a.Fill(DS.Logi);
            int max = 0;
            foreach (StolowkaDS.LogiRow rr in DS.Logi)
            {
                if (rr.Id > max) max = rr.Id;
            }

            StolowkaDS.LogiRow r = DS.Logi.NewLogiRow();
            /*r.Id = Id;
            r.UzytkownikId = Uzytkownik.Id;
            r.Operacja = TypOperacji;
            r.Data = DateTime.Now;
            DS.Logi.Rows.Add(r);*/

            a.Insert(TypOperacji, Uzytkownik.Id, DataOperacji);

            //DS.AcceptChanges();
        }

        /**
         * Wyświetlanie listy logów zapisanych w bazie danych
         * */
        public StolowkaDS.LogiDataTable wyswietlanie()
        {

            StolowkaDS DS = new StolowkaDS();
            StolowkaDSTableAdapters.LogiTableAdapter a = new StolowkaDSTableAdapters.LogiTableAdapter();

            a.Fill(DS.Logi);

            /*tb.Text = "";
            foreach (StolowkaDS.LogiRow rr in DS.Logi)
            {
                tb.Text = tb.Text + rr.Operacja + "\n";
            }*/

            return DS.Logi;
        }
    }
}
