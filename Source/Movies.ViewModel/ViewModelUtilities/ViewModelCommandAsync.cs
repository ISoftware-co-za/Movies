using System;
using System.Threading.Tasks;

namespace Movies.ViewModel.ViewModelUtilities
{
    public abstract class ViewModelCommandAsync : ViewModelCommandBase
    {
        public override async void Execute(object parameter)
        {
            try
            {
                if (Enabled)
                    await PerformAsync();
            }
            catch (Exception exception)
            {
                // ToDo: Should log exception here.
            }
        }

        public abstract Task PerformAsync();
    }
}
