using AutomatInformationSystem.Views;
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
    public class AutomatiPageModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddAutomatCommand { get; set; }

        public ObservableCollection<AutomatItemCardViewModel> Items { get; set; }

        public AutomatiPageModelView()
        {
            this.AddAutomatCommand = new RelayCommand(addAutomatCommand);
            IAutomatDAO dao = new AutomatiImplDAO();
            List<AutomatFullInfoDTO> listaAutomata = dao.GetAllAutomatiFullInfo();
            ObservableCollection<AutomatItemCardViewModel> obsAutomati = new ObservableCollection<AutomatItemCardViewModel>();
            //foreach(AutomatDTO a in listaAutomata)
            //{

            //}
            listaAutomata.ForEach(s => obsAutomati.Add(new AutomatItemCardViewModel(s.ID, s.SerijskiBroj, s.ObjekatInfo, s.Tip, s.Potrosnja.ToString())));
            Items = obsAutomati;
        }

        private void addAutomatCommand()
        {
            AddAutomatWindow win = new AddAutomatWindow();
            win.Show();
        }

    }
}
