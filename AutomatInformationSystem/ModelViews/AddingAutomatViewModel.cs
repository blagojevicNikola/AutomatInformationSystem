using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            IObjektiDAO objDao = new ObjektiImplDAO();
            ILokacijeDAO lokDao = new LokacijeImplDAO();
            ObservableCollection<ObjektiItemViewModel> objektiVM = new ObservableCollection<ObjektiItemViewModel>();
            List<ObjekatDTO> listaObjekata = objDao.GetAllObjekti();
            foreach(ObjekatDTO o in listaObjekata)
            {
                LokacijaDTO tempLok = lokDao.GetLokacijaById(o.LokacijaID);
                objektiVM.Add(new ObjektiItemViewModel(o.Naziv, tempLok.Adresa + "(" + tempLok.Grad + ")"));
            }
            ListaObjekata = objektiVM;
        }

        private string serijskiBroj;
        private string datumPostavljanja;
        private string potrosnja;
        private string tip;


        public ICommand OkCommand { get; set; }

        public string SerijskiBroj { get { return serijskiBroj; } set { serijskiBroj = value; NotifyPropertyChanged("SerijskiBroj"); } }

        public string DatumPostavljanja { get { return datumPostavljanja; } set { datumPostavljanja = value; NotifyPropertyChanged("DatumPostavljanja"); } }

        public string Potrosnja { get { return potrosnja; } set { potrosnja = value; NotifyPropertyChanged("Potrosnja"); } }

        public string Tip { get { return tip; } set { tip = value; NotifyPropertyChanged("Tip"); } }

        public ObservableCollection<ObjektiItemViewModel> ListaObjekata { get; set; }

        private void okExecute()
        {
            ClosingRequest(this, EventArgs.Empty);
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

