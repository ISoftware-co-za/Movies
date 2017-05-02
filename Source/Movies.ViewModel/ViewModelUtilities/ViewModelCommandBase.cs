using System;
using System.Windows.Input;

namespace Movies.ViewModel.ViewModelUtilities
{
    public abstract class ViewModelCommandBase : PropertyChangeNotifier, ICommand
    {

        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (SetField(ref _enabled, value))
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private bool _enabled;

        public bool CanExecute(object parameter)
        {
            return Enabled;
        }

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;
    }
}
