using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EstateManager.Commands
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<T> execute) : this(execute, null) { }

        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }


        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(GetParameter(parameter));
        }

        public virtual void Execute(object parameter)
        {
            if (CanExecute(parameter) && _execute != null)
            {
                T param = GetParameter(parameter);
                _execute(param);
            }
        }

        private T GetParameter(object parameter)
        {
            T param = default(T);
            try
            {
                param = (T)parameter;
            }
            catch { }
            return param;
        }
    }
}
