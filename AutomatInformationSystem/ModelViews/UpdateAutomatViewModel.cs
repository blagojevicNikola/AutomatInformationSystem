using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class UpdateAutomatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand OkCommand { get; set; }
        public ICommand ClearSelectionCommand { get; set; }

        public event EventHandler ClosingRequest;

        private string serijskiBroj;
        private string datumPostavljanja;
        private string potrosnja;
        private string tip;
        private string kapacitet;
        private AutomatDTO automat;

        public string SerijskiBroj { get { return serijskiBroj; } set { serijskiBroj = value; NotifyPropertyChanged("SerijskiBroj"); } }

        public string DatumPostavljanja { get { return datumPostavljanja; } set { datumPostavljanja = value; NotifyPropertyChanged("DatumPostavljanja"); } }

        public string Potrosnja { get { return potrosnja; } set { potrosnja = value; NotifyPropertyChanged("Potrosnja"); } }

        public string Tip { get { return tip; } set { tip = value; NotifyPropertyChanged("Tip"); } }

        public string Kapacitet { get { return kapacitet; } set { kapacitet = value; NotifyPropertyChanged("Kapacitet"); } }

        public ObservableCollection<ObjektiItemViewModel> ListaObjekata { get; set; }

        public UpdateAutomatViewModel(int id, string tip)
        {
            IAutomatDAO dao = new AutomatiImplDAO();
            automat = dao.GetAutomatById(id, tip);
            SerijskiBroj = automat.SerijskiBroj.ToString();
            DatumPostavljanja = automat.DatumPostavljanja.ToString("dd/MM/yyyy");
            Potrosnja = automat.Potrosnja.ToString();
            Tip = automat.Tip;
            if(Tip=="Hrana")
            {
                AutomatHraneDTO temp = (AutomatHraneDTO)automat;
                Kapacitet = temp.Kapacitet.ToString();
            }    
            else
            {
                AutomatKafeDTO temp = (AutomatKafeDTO)automat;
                Kapacitet = temp.Kapacitet.ToString();
            }
            IObjektiDAO objDao = new ObjektiImplDAO();
            List<ObjekatDTO> listaObjekata = objDao.GetAllObjekti();
            ObservableCollection<ObjektiItemViewModel> obsObj = new ObservableCollection<ObjektiItemViewModel>();
            ILokacijeDAO lokDao = new LokacijeImplDAO();
            listaObjekata.ForEach((s) => {
                bool b = false;
                if(s.ID==automat.ObjekatID)
                {
                    b = true;
                }
                LokacijaDTO lokTemp = lokDao.GetLokacijaById(s.LokacijaID);
                obsObj.Add(new ObjektiItemViewModel(s.ID, s.Naziv, lokTemp.Adresa, b));
            });
            ListaObjekata = obsObj;
            OkCommand = new RelayCommand(updateAutomat);
            ClearSelectionCommand = new RelayCommand(clearSelection);
        }

        private void updateAutomat()
        {
            IAutomatDAO dao = new AutomatiImplDAO();
            AutomatDTO newAutomat = null;
            ObjektiItemViewModel temp = ListaObjekata.ToList().Find(s => s.Izabran);
            int? selectedObjId = null;
            if(temp!=null)
            {
                selectedObjId = temp.ID;
            }
            else
            {
                selectedObjId = null;
            }
            if (Tip == "Hrana")
            {
                newAutomat = new AutomatHraneDTO(automat.ID, DateTime.ParseExact(DatumPostavljanja, "dd/MM/yyyy", CultureInfo.InvariantCulture),selectedObjId, Tip, double.Parse(Potrosnja), long.Parse(SerijskiBroj), int.Parse(Kapacitet),0);
            }
            else
            {
                newAutomat = new AutomatKafeDTO(automat.ID, DateTime.ParseExact(DatumPostavljanja, "dd/MM/yyyy", CultureInfo.InvariantCulture), selectedObjId, Tip, double.Parse(Potrosnja), long.Parse(SerijskiBroj), double.Parse(Kapacitet), 0);
            }
            dao.updateAutomat(newAutomat);
            ClosingRequest(this, EventArgs.Empty);
        }

        private void clearSelection()
        {
            if (ListaObjekata.Count > 0)
            {
                foreach (ObjektiItemViewModel o in ListaObjekata)
                {
                    if (o.Izabran)
                    {
                        o.Izabran = false;
                    }
                }
            }
        }

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
