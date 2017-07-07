using System;
using System.Windows.Input;

namespace Banderas.ViewModel
{
    public class ActionCommand<T> : ICommand
    {
        public ActionCommand(Action<T> _action)
        {
            this.action = _action;
        }
        Action<T> action;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)=> action((T)parameter);

    }
}