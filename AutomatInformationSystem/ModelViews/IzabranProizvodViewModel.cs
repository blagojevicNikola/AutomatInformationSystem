using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class IzabranProizvodViewModel
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int Kolicina { get; set; }

        public double Cijena { get; set; }

        public IzabranProizvodViewModel(int id, string naziv, int? kolicina, double cijena)
        {
            ID = id;
            Naziv = naziv;
            if(kolicina==null)
            {
                Kolicina = 0;
            }
            else
            {
                Kolicina = (int)kolicina;
            }
            Cijena = cijena;
        }

        public IzabranProizvodViewModel(int id, string naziv, int kolicina)
        {
            ID = id;
            Naziv = naziv;
            Kolicina = kolicina;
        }

        public IzabranProizvodViewModel(string naziv, double cijena)
        {
            Naziv = naziv;
            Cijena = cijena;
        }
    }
}
