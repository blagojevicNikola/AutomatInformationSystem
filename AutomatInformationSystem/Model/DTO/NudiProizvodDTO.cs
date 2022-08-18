using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class NudiProizvodDTO
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public double Cijena { get; set; }
        public int? Kolicina { get; set; }

        public NudiProizvodDTO(int id, string naziv, string tip, double cijena, int? kolicina)
        {
            ID = id;
            Naziv = naziv;
            Tip = tip;
            Cijena = cijena;
            Kolicina = kolicina;
        }
    }
}
