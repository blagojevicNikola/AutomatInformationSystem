using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatInformationSystem
{
    public class ProizvodiListDesignView
    {
        public static ProizvodiListDesignView Instance => new ProizvodiListDesignView();

        public List<ProizvodItemCardViewModel> Items { get; set; }

        private ProizvodiListDesignView()
        {
            Items = new List<ProizvodItemCardViewModel>
            {
                new ProizvodItemCardViewModel()
                {
                    ID=1,
                    Naziv="Naziv A",
                    Tip= "Hrana"
                },
                new ProizvodItemCardViewModel()
                {
                    ID=2,
                    Naziv="Naziv B",
                    Tip= "Kafa"
                },
                new ProizvodItemCardViewModel()
                {
                    ID=3,
                    Naziv="Naziv C",
                    Tip= "Hrana"
                }
            };
        }
    }
}
