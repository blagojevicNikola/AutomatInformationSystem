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
    public class ChooseWorkerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler ClosingRequest;
        public ObservableCollection<SelectionWorkerViewModel> ListaRadnika { get; set; }
        public ICommand ContinueCommand { get; set; }

        public ChooseWorkerViewModel()
        {
            IZaposleniDAO dao = new ZaposleniImplDAO();
            List<RadnikDTO> sviRadnici = null;
            ObservableCollection<SelectionWorkerViewModel> obsRadnici = new ObservableCollection<SelectionWorkerViewModel>();
            try
            {
                sviRadnici = dao.GetAllRadnici();
                sviRadnici.ForEach(s => obsRadnici.Add(new SelectionWorkerViewModel(s.Sifra, s.Ime, s.Prezime)));
            }catch(MySqlException)
            {
                MessageBox.Show("Greska prilikom ucitavanja radnika!");
            }
            
            ListaRadnika = obsRadnici;
            ContinueCommand = new RelayCommand(continueExecute);
        }

        public SelectionWorkerViewModel getSelectedWorker()
        {
            foreach(SelectionWorkerViewModel s in ListaRadnika)
            {
                if (s.Izabran == true)
                {
                    return s;
                }
            }
            return null;
        }

        private void continueExecute()
        {
            if(getSelectedWorker()!=null)
            {
                ClosingRequest(this, EventArgs.Empty);
            }
        }

    }
}
