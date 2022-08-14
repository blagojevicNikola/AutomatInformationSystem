using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class AutomatKafeDTO : AutomatDTO
    {
        public double Kapacitet { get; set; }

        public AutomatKafeDTO()
        {

        }

        public AutomatKafeDTO(int id, DateTime datumPostavljanja, int? objekatId, string tip, double potrosnja, long serijskiBroj, double kapacitet) : base(id, datumPostavljanja, objekatId, tip, potrosnja, serijskiBroj)
        {
            Kapacitet = kapacitet;
        }

        public AutomatKafeDTO(DateTime datumPostavljanja, int? objekatId, string tip, double potrosnja, long serijskiBroj, double kapacitet) : base(datumPostavljanja, objekatId, tip, potrosnja, serijskiBroj)
        {
            Kapacitet = kapacitet;
        }
    }
}
