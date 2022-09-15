using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                List<SastojciDTO> dostupniSastojci = null;
                ObservableCollection<SastojciViewModel> obsSastojci = new ObservableCollection<SastojciViewModel>();
                try
                {
                    dostupniSastojci = dao.GetAvailableSastojci(id);
                    izabraniSastojci = dao.GetSelectedSastojci(id);
                    //izabraniSastojci = sastojciIds;
                    izabraniSastojci.ForEach(s => obsSastojci.Add(new SastojciViewModel(s.ID, s.Naziv, true)));
                    dostupniSastojci.ForEach((s) => { obsSastojci.Add(new SastojciViewModel(s.ID, s.Naziv, false)); });
                }catch(MySqlException)
                {
                    MessageBox.Show("Greska prilikom ucitavanja sastojaka!");
                }
                ListaSastojaka = obsSastojci;
            }
            
            UpdateCommand = new RelayCommand(updateProizvod);
        }

        private void updateProizvod()
        {
            if(!validateInput())
            {
                return;
            }
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
            try
            {
                dao.updateProizvod(this.id, Naziv, Tip, addList, removeList);
            }
            catch (MySqlException)
            {
                MessageBox.Show("Greska prilikom azuriranja proizvoda!");
            }
            ClosingRequest(this, EventArgs.Empty);
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
            if (string.IsNullOrEmpty(Naziv))
            {
                return false;
            }
            return true;
        }
    }
}
