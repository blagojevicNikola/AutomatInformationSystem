using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class FillReviewModelView
    {

        public string ImePrezime { get; set; }
        public string Datum { get; set; }
        public ICommand CloseCommand { get; set; }

        public event EventHandler ClosingRequest;


        public ObservableCollection<FillWithProizvodViewModel> UbaceniProizvodi { get; set; }

        public FillReviewModelView(int radnikId, int punjenjeId, string tip)
        {
            IPrihodDAO prihodDao = new PrihodImplDAO();
            PunjenjeDTO punjenje = prihodDao.GetPunjenjeById(punjenjeId);
            IZaposleniDAO zaposleniDao = new ZaposleniImplDAO();
            RadnikDTO radnik = zaposleniDao.GetRadnikById(punjenje.RadnikID);
            ImePrezime = radnik.Ime + " " + radnik.Prezime;
            Datum = punjenje.DatumPunjenja.ToString();
            List<ProizvodPunjenjaDTO> tempLista = null;
            if(tip=="Hrana")
            {
                tempLista = prihodDao.GetAllHranaByPunjenje(punjenjeId);
            }
            else
            {
                tempLista = prihodDao.GetAllSastojciByPunjenje(punjenjeId);
            }
            ObservableCollection<FillWithProizvodViewModel> obsLista = new ObservableCollection<FillWithProizvodViewModel>();
            tempLista.ForEach(s => obsLista.Add(new FillWithProizvodViewModel(s.Naziv, s.Kolicina)));
            UbaceniProizvodi = obsLista;
            CloseCommand = new RelayCommand(closeWindow);
        }

        public void closeWindow()
        {
            ClosingRequest(this, EventArgs.Empty);
        }
    }
}
