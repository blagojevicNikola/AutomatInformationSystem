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
    public class UpdateProizvodViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string naziv;
        private List<SastojciDTO> izabraniSastojci;

        private int id;

        public string Naziv { get { return naziv; } set { naziv = value; NotifyPropertyChanged("Naziv"); } }

        public string Tip { get; set; }

        public ICommand UpdateCommand { get; set; }

        public event EventHandler ClosingRequest;

        public ObservableCollection<SastojciViewModel> ListaSastojaka { get; set; }

        public UpdateProizvodViewModel()
        {

        }

        public UpdateProizvodViewModel(int id, string naziv, string tip)
        {
            this.id = id;
            Naziv = naziv;
            Tip = tip;
            if(Tip=="Kafa")
            {
                ISastojciDAO dao = new SastojciImplDAO();
                List<SastojciDTO> dostupniSastojci = dao.GetAvailableSastojci(id);
                izabraniSastojci = dao.GetSelectedSastojci(id);
                //izabraniSastojci = sastojciIds;
                ObservableCollection<SastojciViewModel> obsSastojci = new ObservableCollection<SastojciViewModel>();
                izabraniSastojci.ForEach(s => obsSastojci.Add(new SastojciViewModel(s.ID, s.Naziv, true)));
                dostupniSastojci.ForEach((s) => { obsSastojci.Add(new SastojciViewModel(s.ID, s.Naziv, false)); });
                ListaSastojaka = obsSastojci;
            }
            
            UpdateCommand = new RelayCommand(updateProizvod);
        }

        private void updateProizvod()
        {
            List<int> addList = new List<int>();
            List<int> removeList = new List<int>();
            if(Tip=="Kafa")
            {
                foreach (SastojciViewModel s in ListaSastojaka)
                {
                    if (s.Izabrano && !izabraniSastojci.Any(i => i.ID == s.ID))
                    {
                        addList.Add(s.ID);
                    }
                    if (!s.Izabrano && izabraniSastojci.Any(i => i.ID == s.ID))
                    {
                        removeList.Add(s.ID);
                    }
                }
            }
            IProizvodDAO dao = new ProizvodiImplDAO();
            dao.updateProizvod(this.id, Naziv,Tip, addList, removeList);
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
