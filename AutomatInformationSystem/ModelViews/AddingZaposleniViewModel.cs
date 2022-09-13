using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class AddingZaposleniViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ClosingRequest;
        public event EventHandler ReloadRequest;

        private string ime;
        private string prezime;
        private string telefon;
        private string datumRodjenja;
        private string tip;

        public AddingZaposleniViewModel()
        {
            this.OkCommand = new RelayCommand(okExecute);
        }

        public ICommand OkCommand { get; set; }

        public string Tip { get { return tip; } set { tip = value; NotifyPropertyChanged("Tip"); } }

        public string Ime { get { return ime; } set { ime = value; NotifyPropertyChanged("Ime"); } }
        public string Prezime { get { return prezime; } set { prezime = value; NotifyPropertyChanged("Prezime"); } }
        public string Telefon { get { return telefon; } set { telefon = value; NotifyPropertyChanged("Telefon"); } }
        public string DatumRodjenja { get { return datumRodjenja; } set { datumRodjenja = value; NotifyPropertyChanged("Datum"); } }


        private void okExecute()
        {
            ZaposleniImplDAO dao = new ZaposleniImplDAO();
            DateTime datum = DateTime.ParseExact(datumRodjenja, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            try
            {
                dao.saveZaposleni(Ime, Prezime, Telefon, datum, Tip);
            }
            catch(MySqlException)
            {
                MessageBox.Show("Greska prilikom unosa zaposlenog!");
            }
            ClosingRequest(this, EventArgs.Empty);
            ReloadRequest(this, EventArgs.Empty);
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
