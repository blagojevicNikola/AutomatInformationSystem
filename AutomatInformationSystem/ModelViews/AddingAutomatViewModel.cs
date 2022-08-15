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
    public class AddingAutomatViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ClosingRequest;

        public AddingAutomatViewModel()
        {
            this.OkCommand = new RelayCommand(okExecute);
            this.ClearSelectionCommand = new RelayCommand(clearSelection);
            IObjektiDAO objDao = new ObjektiImplDAO();
            ILokacijeDAO lokDao = new LokacijeImplDAO();
            ObservableCollection<ObjektiItemViewModel> objektiVM = new ObservableCollection<ObjektiItemViewModel>();
            List<ObjekatDTO> listaObjekata = objDao.GetAllObjekti();
            foreach(ObjekatDTO o in listaObjekata)
            {
                LokacijaDTO tempLok = lokDao.GetLokacijaById(o.LokacijaID);
                objektiVM.Add(new ObjektiItemViewModel(o.ID,o.Naziv, tempLok.Adresa + "(" + tempLok.Grad + ")"));
            }
            ListaObjekata = objektiVM;
        }

        private string serijskiBroj;
        private string datumPostavljanja;
        private string potrosnja;
        private string tip;
        private string kapacitet;


        public ICommand OkCommand { get; set; }
        public ICommand ClearSelectionCommand { get; set; }

        public string SerijskiBroj { get { return serijskiBroj; } set { serijskiBroj = value; NotifyPropertyChanged("SerijskiBroj"); } }

        public string DatumPostavljanja { get { return datumPostavljanja; } set { datumPostavljanja = value; NotifyPropertyChanged("DatumPostavljanja"); } }

        public string Potrosnja { get { return potrosnja; } set { potrosnja = value; NotifyPropertyChanged("Potrosnja"); } }

        public string Tip { get { return tip; } set { tip = value; NotifyPropertyChanged("Tip"); } }

        public string Kapacitet { get { return kapacitet; } set { kapacitet = value; NotifyPropertyChanged("Kapacitet"); } }

        public ObservableCollection<ObjektiItemViewModel> ListaObjekata { get; set; }

        private void okExecute()
        {
            IAutomatDAO dao = new AutomatiImplDAO();
            AutomatDTO newAutomat = null;
            if(Tip=="Hrana")
            {
                DateTime datumPost = DateTime.ParseExact(DatumPostavljanja, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                int? objId = getSelectedObjekatId();
                double potros = double.Parse(Potrosnja);
                int serijskiBr = int.Parse(SerijskiBroj);
                int kapacitet = int.Parse(Kapacitet);
                newAutomat = new AutomatHraneDTO(datumPost, objId, Tip,potros, serijskiBr, kapacitet);
            }
            else
            {
                DateTime datumPost = DateTime.ParseExact(DatumPostavljanja, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                int? objId = getSelectedObjekatId();
                double potros = double.Parse(Potrosnja);
                int serijskiBr = int.Parse(SerijskiBroj);
                double kapacitet = double.Parse(Kapacitet);
                newAutomat = new AutomatKafeDTO(datumPost, objId, Tip, potros, serijskiBr, kapacitet);
            }
            dao.saveAutomat(newAutomat);
            ClosingRequest(this, EventArgs.Empty);
        }

        private void clearSelection()
        {
            if(ListaObjekata.Count>0)
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

        private int getSelectedObjekatId()
        {
            return ListaObjekata.ToList().Find(s => s.Izabran == true).ID;
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

