using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class PrihodDTO
    {
        public int AutomatID { get; set; }
        public int RadnikID { get; set; }
        public DateTime DatumPunjenja { get; set; }
        public double Cijena { get; set; }

        public PrihodDTO(int automatId, int radnikId, DateTime datumPunjenja, double cijena)
        {
            AutomatID = automatId;
            RadnikID = radnikId;
            DatumPunjenja = datumPunjenja;
            Cijena = cijena;
        }
    }
}
