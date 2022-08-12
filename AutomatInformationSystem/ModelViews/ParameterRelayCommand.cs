using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatInformationSystem
{
    class ParameterRelayCommand : ICommand
    {
        private Action<object> _action;
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public ParameterRelayCommand(Action<object> a)
        {
            _action = a;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
