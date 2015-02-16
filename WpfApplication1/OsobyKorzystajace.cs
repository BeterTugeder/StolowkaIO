using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stolowka
{
    class OsobyKorzystajace
    {
        private enum NAZWA { wychowankowie, personel, inne };
        private int ilosc;

        public int Ilosc
        {
            get { return ilosc; }
            set { ilosc = value; }
        }
        private NAZWA nazwa;

        private NAZWA Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }
    }
}
