using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class ZaposleniItemCardDesignView:ZaposleniItemCardViewModel
    {

        public static ZaposleniItemCardDesignView Instance => new ZaposleniItemCardDesignView();

        private ZaposleniItemCardDesignView()
        {
            ID = 1;
            Ime = "Nikola";
            Prezime = "Nikolic";
            BrojTelefona = "066/634-123";
            Tip = "Radnik";
            DatumRodjenja = new DateTime(1994, 03, 01);
        }
    }
}
