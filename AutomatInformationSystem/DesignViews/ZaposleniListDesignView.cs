using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class ZaposleniListDesignView
    {
        public static ZaposleniListDesignView Instance => new ZaposleniListDesignView();

        public List<ZaposleniItemCardViewModel> Items { get; set; }

        private ZaposleniListDesignView()
        {
            Items = new List<ZaposleniItemCardViewModel>()
            {
                new ZaposleniItemCardViewModel
                {
                    ID = 1,
                    Ime = "Nikola",
                    Prezime = "Nikolic",
                    BrojTelefona = "066/234-412",
                    Tip = "Radnik",
                    DatumRodjenja = new DateTime(1973,12,03)
                },
                new ZaposleniItemCardViewModel
                {
                    ID = 1,
                    Ime = "Dejan",
                    Prezime = "Dejanovic",
                    Tip = "Serviser",
                    BrojTelefona = "066/124-418",
                    DatumRodjenja = new DateTime(1983,11,15)
                },
                new ZaposleniItemCardViewModel
                {
                    ID = 1,
                    Ime = "Marko",
                    Prezime = "Markovic",
                    BrojTelefona = "066/584-111",
                    Tip = "Radnik",
                    DatumRodjenja = new DateTime(1993,07,22)
                }
            };
        }
    }
}
