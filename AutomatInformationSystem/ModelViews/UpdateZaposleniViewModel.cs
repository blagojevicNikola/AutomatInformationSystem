using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class UpdateZaposleniViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ClosingRequest;

        private int id;
        private string ime;
        private string prezime;
        private string telefon;
        private string datumRodjenja;
        private string tip;

        public UpdateZaposleniViewModel(int id, string ime, string prezime, string telefon, string datumRodjenja, string tip)
        {
            this.id = id;
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
            DatumRodjenja = datumRodjenja;
            Tip = tip;
            this.OkCommand = new RelayCommand(okExecute);
        }

        public ICommand OkCommand { get; set; }

        public string Tip { get { return tip; } set { tip = value; NotifyPropertyChanged("Tip"); } }

        public string Ime { get { return ime; } set { ime = value; NotifyPropertyChanged("Ime"); } }
        public string Prezime { get { return prezime; } set { prezime = value; NotifyPropertyChanged("Prezime"); } }
        public string Telefon { get { return telefon; } set { telefon = value; NotifyPropertyChanged("Telefon"); } }
        public string DatumRodjenja { get { return datumRodjenja; } set { datumRodjenja = value; NotifyPropertyChanged("Datum"); } }

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void okExecute()
        {
            IZaposleniDAO dao = new ZaposleniImplDAO();
            DateTime datumRodj = DateTime.ParseExact(DatumRodjenja, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ZaposleniDTO newZaposleni = null;
            if(Tip=="Radnik")
            {
                newZaposleni =new RadnikDTO(this.id, Ime, Prezime, Telefon, datumRodj, Tip);
            }
            else
            {
                newZaposleni = new ServiserDTO(this.id, Ime, Prezime, Telefon, datumRodj, Tip);
            }
            dao.updateZaposleni(newZaposleni);
            ClosingRequest(this, EventArgs.Empty);
        }
    }
}
