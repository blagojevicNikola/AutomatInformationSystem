using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class AutomatFullInfoDTO
    {
        public int ID { get; set; }
        public DateTime DatumPostavljanja { get; set; }
        public string Tip { get; set; }

        public double Potrosnja { get; set; }

        public long SerijskiBroj { get; set; }

        public string Kapacitet { get; set; }
        public string ObjekatInfo { get; set; }

        public AutomatFullInfoDTO()
        {

        }

        public AutomatFullInfoDTO(int id, DateTime datumPostavljanja, int? objekatId, string tip, double potrosnja, long serijskiBroj, string kapacitet, string nazivObjekta, string grad, string adresa)
        {
            ID = id;
            DatumPostavljanja = datumPostavljanja;
            Tip = tip;
            Potrosnja = potrosnja;
            SerijskiBroj = serijskiBroj;
            Kapacitet = kapacitet;
            if(objekatId==null)
            {
                ObjekatInfo = "Nedostupno";
            }
            else
            {
                ObjekatInfo = nazivObjekta + "-(" + adresa + ", " + grad + ")";
            }
        }

    }
}
