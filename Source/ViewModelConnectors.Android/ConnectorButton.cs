using Android.Widget;
using Movies.ViewModel.ViewModelUtilities;

namespace ViewModelConnectors.Android
{
    public class ConnectorButton
    {
        public ConnectorButton(Button button, ViewModelCommandBase command)
        {
            button.Click += (sender, args) =>
            {
                command.Execute(null);
            };

            button.Enabled = command.CanExecute(null);
            command.CanExecuteChanged += (sender, args) =>
            {
                button.Enabled = command.Enabled;
            };
        }
    }
}