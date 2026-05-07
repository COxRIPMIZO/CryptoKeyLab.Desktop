using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoKeyLab.Desktop.Helper
{
    public class RelayCommand<T> : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Action<T?> _execute;

        /// <summary>
        /// 
        /// </summary>
        private readonly Predicate<T?>? _canExecute;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="predicate"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action<T?> action,Predicate<T?>? predicate = null)
        {
            if(action is null)
                throw new ArgumentNullException("Action not define.",nameof(action));

            _execute = action;
            _canExecute = predicate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter) => _canExecute?.Invoke((T?) parameter) ?? true;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            _execute.Invoke((T?) parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        public void NotifyCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
