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
    public class ManageAutomatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler ClosingRequest;


        private string sifra;
        private string cijena;
        private string kolicina;
        private bool dostupnaKolicina;
        private int automatId;
        private string automatTip;
        public string Sifra { get { return sifra; } set { sifra = value; NotifyPropertyChanged("Sifra"); } }

        public string Cijena
        {
            get { return cijena; }
            set { cijena = value; NotifyPropertyChanged("Cijena"); }
        }

        public string Kolicina { get { return kolicina; } set { kolicina = value; NotifyPropertyChanged("Kolicina"); } }

        public bool DostupnaKolicina { get { return dostupnaKolicina; } set { dostupnaKolicina = value; NotifyPropertyChanged("DostupnaKolicina"); } }

        public ObservableCollection<DostupanProizvodViewModel> ListaSvihProizvoda { get; set; }
        public ObservableCollection<IzabranProizvodViewModel> ListaIzabranihProizvoda { get; set; }

        public DostupanProizvodViewModel ToBeAdded { get; set; }
        public IzabranProizvodViewModel ToBeRemoved { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand OkCommand { get; set; }

        public ManageAutomatViewModel(int sifra, string tip)
        {
            IAutomatDAO dao = new AutomatiImplDAO();
            AutomatDTO automat = dao.GetAutomatById(sifra, tip);
            if (automat != null)
            {
                Sifra = automat.SerijskiBroj.ToString();
                automatId = automat.ID;
                automatTip = automat.Tip;
                IProizvodDAO proDao = new ProizvodiImplDAO();
                List<ProizvodDTO> proizvodiTempList;
                List<NudiProizvodDTO> ubaceniProizvodiList;
                if (automat.Tip == "Hrana")
                {
                    DostupnaKolicina = true;
                    proizvodiTempList = proDao.GetAllProizvodHrana();
                    ubaceniProizvodiList = proDao.GetAllHranaOfAutomat(automatId);
                }
                else
                {
                    DostupnaKolicina = false;
                    proizvodiTempList = proDao.GetAllProizvodKafa();
                    ubaceniProizvodiList = proDao.GetAllKafaOfAutomat(automatId);
                }
                ObservableCollection<DostupanProizvodViewModel> obsProizvodi = new ObservableCollection<DostupanProizvodViewModel>();
                proizvodiTempList.ForEach(s => obsProizvodi.Add(new DostupanProizvodViewModel(s.ID, s.Naziv)));
                ObservableCollection<IzabranProizvodViewModel> obsIzabrani = new ObservableCollection<IzabranProizvodViewModel>();
                ubaceniProizvodiList.ForEach(s => obsIzabrani.Add(new IzabranProizvodViewModel(s.ID, s.Naziv, s.Kolicina, s.Cijena)));
                ListaSvihProizvoda = obsProizvodi;
                ListaIzabranihProizvoda = obsIzabrani;
                AddCommand = new RelayCommand(addProizvod);
                RemoveCommand = new RelayCommand(removeProizvod);
            }

        }

        private void okExecute()
        {
            ClosingRequest(this, EventArgs.Empty);
        }

        private void addProizvod()
        {
            if(ToBeAdded!=null && double.TryParse(Cijena, out _) && !ListaIzabranihProizvoda.Any(s => s.ID==ToBeAdded.ID))
            {
                if(int.TryParse(Kolicina, out _))
                {
                    ListaIzabranihProizvoda.Add(new IzabranProizvodViewModel(ToBeAdded.ID, ToBeAdded.Naziv, int.Parse(Kolicina), double.Parse(Cijena)));
                }
                else
                {
                    ListaIzabranihProizvoda.Add(new IzabranProizvodViewModel(ToBeAdded.ID, ToBeAdded.Naziv, null, double.Parse(Cijena)));
                }
            }
        }

        private void removeProizvod()
        {
            if(ToBeRemoved!=null)
            {
                ListaIzabranihProizvoda.Remove(ToBeRemoved);
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
