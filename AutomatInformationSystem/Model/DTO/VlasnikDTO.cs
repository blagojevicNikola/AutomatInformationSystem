using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class VlasnikDTO
    {
        public int ID { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Telefon { get; set; }

        public VlasnikDTO()
        {

        }

        public VlasnikDTO(int id, string ime, string prezime, string telefon)
        {
            ID = id;
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
        }

        public VlasnikDTO(string ime, string prezime, string telefon)
        {
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
        }
    }
}
