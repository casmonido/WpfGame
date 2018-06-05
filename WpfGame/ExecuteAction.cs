using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfGame
{
    public class ExecuteAction : ICommand
    {
        private Action<object> execute;
        public ExecuteAction(Action<object> execute)
        {
            this.execute = execute;
        }
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }
}
