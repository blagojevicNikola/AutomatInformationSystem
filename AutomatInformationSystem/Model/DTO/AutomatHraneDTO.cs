using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class AutomatHraneDTO : AutomatDTO
    {
        public int Kapacitet { get; set; }

        public AutomatHraneDTO()
        {

        }

        public AutomatHraneDTO(int id, DateTime datumPostavljanja, int? objekatId, string tip, double potrosnja, int serijskiBroj, int kapacitet):base(id, datumPostavljanja, objekatId, tip, potrosnja, serijskiBroj)
        {
            Kapacitet = kapacitet;
        }

        public AutomatHraneDTO(DateTime datumPostavljanja, int? objekatId, string tip, double potrosnja, int serijskiBroj, int kapacitet):base(datumPostavljanja, objekatId, tip, potrosnja, serijskiBroj)
        {
            Kapacitet = kapacitet;
        }
    }
}
