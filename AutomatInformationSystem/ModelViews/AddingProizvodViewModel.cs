using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class AddingProizvodViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ClosingRequest;

        public AddingProizvodViewModel()
        {
            this.OkCommand = new RelayCommand(okExecute);
        }

        public ICommand OkCommand { get; set; }

        private string naziv;
        private string tip;

        public string Tip { get { return tip; } set { tip = value; NotifyPropertyChanged("Tip"); } }

        public string Naziv { get { return naziv; } set { naziv = value; NotifyPropertyChanged("Naziv"); } }

        private void okExecute()
        {
            IProizvodDAO dao = new ProizvodiImplDAO();
            dao.saveProizvod(Naziv, Tip);
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
