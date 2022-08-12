using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class ZaposleniItemCardViewModel
    {

        private string _brojTelefona;

        public int ID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Tip { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public string BrojTelefona { get { return _brojTelefona; }  set { if (string.IsNullOrEmpty(value)) { _brojTelefona = "empty"; }
                else { _brojTelefona = value; }
            } }


        public ZaposleniItemCardViewModel()
        {

        }

        public ZaposleniItemCardViewModel(int id, string ime, string prezime, string brojTelefona, DateTime datumRodjenja, string tip)
        {
            ID = id;
            Ime = ime;
            Prezime = prezime;
            BrojTelefona = brojTelefona;
            DatumRodjenja = datumRodjenja;
            Tip = tip;
        }

        public ZaposleniItemCardViewModel(string ime, string prezime, string brojTelefona, DateTime datumRodjenja, string tip)
        {
            Ime = ime;
            Prezime = prezime;
            BrojTelefona = brojTelefona;
            DatumRodjenja = datumRodjenja;
            Tip = tip;
        }

    }
}
