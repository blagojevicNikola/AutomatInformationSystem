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
        }

        private void addAutomatCommand()
        {
            AddAutomatWindow win = new AddAutomatWindow();
            win.Show();
        }

    }
}
