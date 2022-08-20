using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class FillWithProizvodViewModel
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Kolicina { get; set; }

        public FillWithProizvodViewModel(int id, string naziv, string kolicina)
        {
            ID = id;
            Naziv = naziv;
            Kolicina = kolicina;
        }
    }
}
