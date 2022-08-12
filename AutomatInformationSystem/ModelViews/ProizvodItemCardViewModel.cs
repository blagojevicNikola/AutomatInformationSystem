using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class ProizvodItemCardViewModel
    {
        public int ID { get; set; }

        public string Naziv { get; set; }

        public string Tip { get; set; }

        public ProizvodItemCardViewModel()
        {

        }

        public ProizvodItemCardViewModel(int id, string naziv, string tip)
        {
            ID = id;
            Naziv = naziv;
            Tip = tip;
        }

        public ProizvodItemCardViewModel(string naziv, string tip)
        {
            Naziv = naziv;
            Tip = tip;
        }

    }
}
