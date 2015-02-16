using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stolowka
{
    class WydaneProdukty
    {
        private Produkt produkt;

        internal Produkt Produkt
        {
            get { return produkt; }
            set { produkt = value; }
        }
        private int ilosc;

        public int Ilosc
        {
            get { return ilosc; }
            set { ilosc = value; }
        }
        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public double liczWartosc()
        {
            return 0.0;
        }
    }
}
