using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class AutomatiListDesignView
    {

        public static AutomatiListDesignView Instance => new AutomatiListDesignView();


        public List<AutomatItemCardViewModel> Items { get; set; }
        private AutomatiListDesignView()
        {
            Items = new List<AutomatItemCardViewModel>
            { 
               new AutomatItemCardViewModel
               {
                   ID = 1,
                   Sifra = "13543474831",
                   Lokacija = "Neka tamo lijeva 9",
                   Tip = "Kafa",
                   Potrosnja = "231"
               },
               new AutomatItemCardViewModel
               {
                   ID = 2,
                   Sifra = "13546374831",
                   Lokacija = "Neka tamo desna 4",
                   Tip = "Hrana",
                   Potrosnja = "231"
               },
               new AutomatItemCardViewModel
               {
                   ID = 1,
                   Sifra = "13361174831",
                   Lokacija = "Neka tamo nesto 41",
                   Tip = "Kafa",
                   Potrosnja = "231"
               },
                new AutomatItemCardViewModel
               {
                   ID = 1,
                   Sifra = "13543474831",
                   Lokacija = "Neka tamo lijeva 9",
                   Tip = "Hrana"
                   ,
                   Potrosnja = "231"
               },
               new AutomatItemCardViewModel
               {
                   ID = 2,
                   Sifra = "13546374831",
                   Lokacija = "Neka tamo desna 4",
                   Tip = "Kafa"
                   ,
                   Potrosnja = "231"
               },
               new AutomatItemCardViewModel
               {
                   ID = 1,
                   Sifra = "13361174831",
                   Lokacija = "Neka tamo nesto 41",
                   Tip = "Hrana",
                   Potrosnja = "231"
        }
    };

        }
    }
}
