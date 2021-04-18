using System;
using System.Windows.Input;

namespace HexEditor.AdditionalClasses
{
    internal class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> action;

        public MyCommand(Action<object> _action)
        {
            action = _action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
