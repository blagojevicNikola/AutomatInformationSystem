using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public abstract class AutomatDTO
    {
        public int ID { get; set; }
        public DateTime DatumPostavljanja { get; set; }
        public int? ObjekatID { get; set; }

        public string Tip { get; set; }

        public double Potrosnja { get; set; }

        public long SerijskiBroj { get; set; }

        public double UkupanPrihod { get; set; }

        public AutomatDTO()
        {

        }

        public AutomatDTO(int id, DateTime datumPostavljanja, int? objekatId, string tip, double potrosnja, long serijskiBroj, double ukupanPrihod)
        {
            ID = id;
            DatumPostavljanja = datumPostavljanja;
            ObjekatID = objekatId;
            Tip = tip;
            Potrosnja = potrosnja;
            SerijskiBroj = serijskiBroj;
            UkupanPrihod = ukupanPrihod;
        }

        public AutomatDTO(DateTime datumPostavljanja, int? objekatId, string tip, double potrosnja, long serijskiBroj)
        {
            DatumPostavljanja = datumPostavljanja;
            ObjekatID = objekatId;
            Tip = tip;
            Potrosnja = potrosnja;
            SerijskiBroj = serijskiBroj;
        }
    }
}
