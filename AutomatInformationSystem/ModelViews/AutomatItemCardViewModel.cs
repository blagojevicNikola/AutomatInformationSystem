using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class AutomatItemCardViewModel
    {

        private string _potrosnja;
        public int ID { get; set; }

        public int Sifra { get; set; }

        public string Lokacija { get; set; }

        public string Tip { get; set; }

        public string Potrosnja { get { return _potrosnja; } set { _potrosnja = value + "W"; } }

        public AutomatItemCardViewModel()
        {

        }

        public AutomatItemCardViewModel(int id, int sifra, string lokacija, string tip, string potrosnja )
        {
            ID = id;
            Sifra = sifra;
            Lokacija = lokacija;
            Tip = tip;
            Potrosnja = potrosnja;
        }
    }
}
