using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatTVP2.ViewModels.Commands
{
    class SimpleCommand : ICommand
    {
        private Action _action;

        #region ICommand
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this._action();
        }
        #endregion

        public SimpleCommand(Action action)
        {
            _action = action;
        }
    }
}
