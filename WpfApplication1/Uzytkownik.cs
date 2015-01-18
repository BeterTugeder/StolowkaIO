using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stolowka
{
    class Uzytkownik
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string imie;

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        string nazwisko;

        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        bool typ;

        public bool Typ
        {
            get { return typ; }
            set { typ = value; }
        }
    }
}
