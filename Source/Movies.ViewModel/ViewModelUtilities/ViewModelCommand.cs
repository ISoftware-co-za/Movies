using System;
using System.Threading.Tasks;

namespace Movies.ViewModel.ViewModelUtilities
{
    public abstract class ViewModelCommand: ViewModelCommandBase
    {
        public override void Execute(object parameter)
        {
            try
            {
                if (Enabled)
                    Perform();
            }
            catch (Exception exception)
            {
                // ToDo: Should log exception here.
            }
        }

        public abstract void Perform();
    }
}
