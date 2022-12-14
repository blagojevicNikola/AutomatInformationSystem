using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class AddingAutomatViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ClosingRequest;
        public event EventHandler ReloadRequest;
        public AddingAutomatViewModel()
        {
            this.OkCommand = new RelayCommand(okExecute);
            this.ClearSelectionCommand = new RelayCommand(clearSelection);
            IObjektiDAO objDao = new ObjektiImplDAO();
            ILokacijeDAO lokDao = new LokacijeImplDAO();
            ObservableCollection<ObjektiItemViewModel> objektiVM = new ObservableCollection<ObjektiItemViewModel>();

            List<ObjekatDTO> listaObjekata = null;
            try
            {
                listaObjekata = objDao.GetAllObjekti();
                if(listaObjekata!=null)
                {
                    foreach (ObjekatDTO o in listaObjekata)
                    {
                        LokacijaDTO tempLok = lokDao.GetLokacijaById(o.LokacijaID);
                        objektiVM.Add(new ObjektiItemViewModel(o.ID, o.Naziv, tempLok.Adresa + "(" + tempLok.Grad + ")"));
                    }
                }
                ListaObjekata = objektiVM;
            }catch(MySqlException)
            {
                MessageBox.Show("Greska!");
            }
            
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
            if(!validateInput())
            {
                return;
            }
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
            try
            {
                dao.saveAutomat(newAutomat);
            }catch(MySqlException)
            {
                MessageBox.Show("Greska prilikom upisa automata!");
            }
            ReloadRequest(this, EventArgs.Empty);
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

        private int? getSelectedObjekatId()
        {
            ObjektiItemViewModel objTemp = ListaObjekata.ToList().Find(s => s.Izabran == true);
            if(objTemp!=null)
            {
                return objTemp.ID;
            }
            return null;
        }

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private bool validateInput()
        {
           if(string.IsNullOrEmpty(SerijskiBroj) || !int.TryParse(SerijskiBroj, out _))
            {
                return false;
            }

            if (string.IsNullOrEmpty(DatumPostavljanja) || !DateTime.TryParseExact(DatumPostavljanja, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return false;
            }

            if (string.IsNullOrEmpty(Potrosnja) || !double.TryParse(Potrosnja, out _))
            {
                return false;
            }
           if(string.IsNullOrEmpty(Kapacitet) || !int.TryParse(Kapacitet, out _) || !double.TryParse(Kapacitet, out _))
            {
                return false;
            }

            return true;
        }
    }
}

