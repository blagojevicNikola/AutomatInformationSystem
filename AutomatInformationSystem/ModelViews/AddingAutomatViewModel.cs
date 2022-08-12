using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    public class AddingAutomatViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ClosingRequest;

        public AddingAutomatViewModel()
        {
            this.OkCommand = new RelayCommand(okExecute);
        }

        public ICommand OkCommand { get; set; }

        public string SelectedType { get; set; }

        public string Name { get; set; }

        private void okExecute()
        {
            ClosingRequest(this, EventArgs.Empty);
        }
    }
}

