using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stolowka
{
    class Potrawy
    {
        private enum TYP { sniadanie, obiad, kolacja }
        private string nazwa;

        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }
        private TYP typ;

        private TYP Typ
        {
            get { return typ; }
            set { typ = value; }
        }

        public void dodaj()
        {

        }
    }
}
