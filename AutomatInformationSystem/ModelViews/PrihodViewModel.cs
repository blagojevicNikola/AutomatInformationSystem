using AutomatInformationSystem.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class PrihodViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string tip;
        public int PunjenjeID { get; set; }
        public int AutomatID { get; set; }
        public int RadnikID { get; set; }
        public string DatumPunjenja { get; set; }
        public string Prihod { get; set; }
        public ICommand InfoCommand { get; set; }

        public PrihodViewModel(int automatId, int radnikId, string datumPunjenja, string prihod, string tip)
        {
            AutomatID = automatId;
            RadnikID = radnikId;
            DatumPunjenja = datumPunjenja;
            Prihod = prihod;
            this.tip = tip;
            InfoCommand = new RelayCommand(getInformation);
        }
        public PrihodViewModel(int punjenjeId, int automatId, int radnikId, string datumPunjenja, string prihod, string tip)
        {
            PunjenjeID = punjenjeId;
            AutomatID = automatId;
            RadnikID = radnikId;
            DatumPunjenja = datumPunjenja;
            Prihod = prihod;
            this.tip = tip;
            InfoCommand = new RelayCommand(getInformation);
        }

        public void getInformation()
        {
            FillReviewModelView vm = new FillReviewModelView(RadnikID, PunjenjeID, tip);
            FillReviewWindow win = new FillReviewWindow();
            vm.ClosingRequest += (sender, a) => win.Close();
            win.DataContext = vm;
            win.Show();

        }
    }
}
