using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{ 
    public class ServiserDTO : ZaposleniDTO
    {
        public ServiserDTO(int sifra, string ime, string prezime, string telefon, DateTime datumRodjenja, string tip):base(sifra, ime, prezime, telefon, datumRodjenja, tip)
        {

        }
        public ServiserDTO(string ime, string prezime, string telefon, DateTime datumRodjenja, string tip) : base(ime, prezime, telefon, datumRodjenja, tip)
        {

        }

    }
}
