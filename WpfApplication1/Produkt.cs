using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stolowka
{
    class Produkt
    {
        private string nazwa;

        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }
        private string jedn_miary;

        public string Jedn_miary
        {
            get { return jedn_miary; }
            set { jedn_miary = value; }
        }
        private float cena_jedn;

        public float Cena_jedn
        {
            get { return cena_jedn; }
            set { cena_jedn = value; }
        }
        private string numer_kartoteki;

        public string Numer_kartoteki
        {
            get { return numer_kartoteki; }
            set { numer_kartoteki = value; }
        }
        private string pozycja_kartoteki;

        public string Pozycja_kartoteki
        {
            get { return pozycja_kartoteki; }
            set { pozycja_kartoteki = value; }
        }
    }
}
