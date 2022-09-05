using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class ProizvodPunjenjaDTO
    {
        public string Naziv { get; set; }
        public string Kolicina { get; set; }

        public ProizvodPunjenjaDTO(string naziv, string kolicina)
        {
            Naziv = naziv;
            Kolicina = kolicina;
        }
    }
}
