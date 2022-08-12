using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public abstract class ZaposleniDTO
    {
        private int sifra;
        private string ime;
        private string prezime;
        private string telefon;
        private DateTime datumRodjenja;
        private string tip;

        public int Sifra { get { return sifra; } set { sifra = value; } }

        public string Ime { get { return ime; } set { ime = value; } }

        public string Prezime { get { return prezime; } set { prezime = value; } }

        public string Telefon { get { return telefon; } set { telefon = value; } }

        public DateTime DatumRodjenja { get { return datumRodjenja; } set { datumRodjenja = value; } }

        public string Tip { get { return tip; } set { tip = value; } }

        public ZaposleniDTO(int sifra, string ime, string prezime, string telefon, DateTime datumRodjenja, string tip)
        {
            Sifra = sifra;
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
            DatumRodjenja = datumRodjenja;
            Tip = tip;
        }

        public ZaposleniDTO(string ime, string prezime, string telefon, DateTime datumRodjenja, string tip)
        {
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
            DatumRodjenja = datumRodjenja;
            Tip = tip;
        }
    }
}
