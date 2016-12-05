using System;
using System.Windows.Input;

namespace CalculatorClient.ViewModel
{
    public class CalculationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action _method;
        private bool _canExecute;

        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public CalculationCommand(Action method)
        {
            _method = method;
            _canExecute = true;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _method();
        }
    }
}