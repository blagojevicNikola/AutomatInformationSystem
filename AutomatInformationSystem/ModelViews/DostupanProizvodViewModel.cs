using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class DostupanProizvodViewModel
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        public DostupanProizvodViewModel(int id, string naziv)
        {
            ID = id;
            Naziv = naziv;
        }
    }
}
