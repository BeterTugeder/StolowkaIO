using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stolowka
{
    class Zasob
    {
        string nazwa;

        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }

        double ilosc;

        public double Ilosc
        {
            get { return ilosc; }
            set { ilosc = value; }
        }

        double cenaJedn;

        public double CenaJedn
        {
            get { return cenaJedn; }
            set { cenaJedn = value; }
        }
    }
}
