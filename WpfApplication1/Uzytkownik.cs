using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
/*
 * Hashowanie hasła: SHA512
 * */
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

        bool zalogowany = false;

        public bool Zalogowany
        {
            get { return zalogowany; }
        }

        private static string GetSHA512(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            SHA512Managed hashString = new SHA512Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        public void logowanie(string haslo)
        {
            haslo = GetSHA512(haslo);

            StolowkaDS ds = new StolowkaDS();
            StolowkaDSTableAdapters.UzytkownicyTableAdapter ad = new StolowkaDSTableAdapters.UzytkownicyTableAdapter();

            ad.Fill(ds.Uzytkownicy);

            DataRow[] dr = ds.Uzytkownicy.Select("login = '" + Login + "' AND haslo = '" + haslo + "'");
            if (dr.Length > 0)
            {
                zalogowany = true;
            }
            else
            {
                zalogowany = false;
            }
        }

        public bool istnieje()
        {
            StolowkaDS ds = new StolowkaDS();
            StolowkaDSTableAdapters.UzytkownicyTableAdapter ad = new StolowkaDSTableAdapters.UzytkownicyTableAdapter();

            ad.Fill(ds.Uzytkownicy);

            DataRow[] dr = ds.Uzytkownicy.Select("login = '" + Login + "'");
            if (dr.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void wylogowanie()
        {
            zalogowany = false;
        }

        public void edycja(string haslo)
        {
            haslo = GetSHA512(haslo);

            StolowkaDS ds = new StolowkaDS();
            StolowkaDSTableAdapters.UzytkownicyTableAdapter ad = new StolowkaDSTableAdapters.UzytkownicyTableAdapter();

            ad.Fill(ds.Uzytkownicy);

            byte typ;
            if (Typ)
                typ = 1;
            else
                typ = 0;

            ad.Update( Login, haslo, Imie, Nazwisko, typ, Id );
        }

        public void usuwanie()
        {
            StolowkaDS ds = new StolowkaDS();
            StolowkaDSTableAdapters.UzytkownicyTableAdapter ad = new StolowkaDSTableAdapters.UzytkownicyTableAdapter();

            ad.Fill(ds.Uzytkownicy);

            ad.Delete(Id);
        }

        public void dodawanie(string haslo)
        {
            haslo = GetSHA512(haslo);

            StolowkaDS ds = new StolowkaDS();
            StolowkaDSTableAdapters.UzytkownicyTableAdapter ad = new StolowkaDSTableAdapters.UzytkownicyTableAdapter();

            ad.Fill(ds.Uzytkownicy);

            byte typ;
            if (Typ)
                typ = 1;
            else
                typ = 0;

            ad.Insert( Login, haslo, Imie, Nazwisko, typ );

            Console.WriteLine("dodano");
        }

        public StolowkaDS.UzytkownicyDataTable lista()
        {

            StolowkaDS ds = new StolowkaDS();
            StolowkaDSTableAdapters.UzytkownicyTableAdapter ad = new StolowkaDSTableAdapters.UzytkownicyTableAdapter();

            ad.Fill(ds.Uzytkownicy);

            return ds.Uzytkownicy;
        }
    }
}
