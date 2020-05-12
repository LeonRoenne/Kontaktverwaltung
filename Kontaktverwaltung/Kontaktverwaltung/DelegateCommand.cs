using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Kontaktverwaltung
{
    public class DelegateCommand : ICommand
    {
        private Action _eventHandler;

        public DelegateCommand(Action handler)
        {
            _eventHandler = handler;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _eventHandler();
        }
    }
}
