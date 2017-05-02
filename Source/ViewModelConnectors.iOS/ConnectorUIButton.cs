using Movies.ViewModel.ViewModelUtilities;
using UIKit;

namespace ViewModelConnectors.iOS
{
    public class ConnectorUIButton
    {
        public ConnectorUIButton(UIButton button, ViewModelCommandBase command)
        {
            button.TouchUpInside += (sender, args) =>
            {
                command.Execute(null);
            };

            command.CanExecuteChanged += (sender, args) =>
            {
                button.Enabled = command.Enabled;
            };

            button.Enabled = command.Enabled;
        }
    }
}
