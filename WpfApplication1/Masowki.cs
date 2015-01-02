using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stolowka
{
    class Masowki
    {
        int czasTrwania;
        public int CzasTrwania
        {
            get { return czasTrwania; }
            set { czasTrwania = value; }
        }

        List<Zasob> zasoby;


        public double LiczKoszt()
        {
            double suma = 0.0;
            for (int i = 0; i < zasoby.Count(); i++)
            {
                suma = suma + zasoby[i].Ilosc*zasoby[i].CenaJedn;
            }
            return suma;
        }
    }
}
