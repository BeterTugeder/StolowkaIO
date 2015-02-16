using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stolowka
{
    class Raport
    {
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private List<WydaneProdukty> wydane;

        internal List<WydaneProdukty> Wydane
        {
            get { return wydane; }
            set { wydane = value; }
        }
        private List<Potrawy> potrawy;

        internal List<Potrawy> Potrawy
        {
            get { return potrawy; }
            set { potrawy = value; }
        }
        private List<OsobyKorzystajace> osoby;

        internal List<OsobyKorzystajace> Osoby
        {
            get { return osoby; }
            set { osoby = value; }
        }

        /*
         * Pobiera wszystkie dane do raportu
         * */
        public void generuj()
        {

        }

        /*
         * Prawdopodobnie totalnie bez sensu!
         * */
        public void drukuj()
        {

        }
    }
}
