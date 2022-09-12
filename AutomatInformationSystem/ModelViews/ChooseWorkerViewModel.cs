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
    public class ChooseWorkerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler ClosingRequest;
        public ObservableCollection<SelectionWorkerViewModel> ListaRadnika { get; set; }
        public ICommand ContinueCommand { get; set; }

        public ChooseWorkerViewModel()
        {
            IZaposleniDAO dao = new ZaposleniImplDAO();
            List<RadnikDTO> sviRadnici = dao.GetAllRadnici();
            ObservableCollection<SelectionWorkerViewModel> obsRadnici = new ObservableCollection<SelectionWorkerViewModel>();
            sviRadnici.ForEach(s => obsRadnici.Add(new SelectionWorkerViewModel(s.Sifra, s.Ime, s.Prezime)));
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
