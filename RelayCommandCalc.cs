using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyCalculator
{
    public class RelayCommandCalc:ICommand
    {

        readonly Action<Object> _execute;
        readonly Predicate<Object> _canExecute;

        public RelayCommandCalc(Action<Object> execute) : this(execute, null)
        { }

        public RelayCommandCalc(Action<object> execute, Predicate<object> canExecute)
        {//consructor
            if (execute == null)
            {
                throw new ArgumentNullException("execute method missing");
            }
            _execute = execute;
            _canExecute = canExecute;

        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);

        }

        public void Execute(object parameter) //what to execute
        {
            
            _execute(parameter); //delegate invoke =method name
            
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

     //   public event EventHandler CanExecuteChanged;
    }
}
