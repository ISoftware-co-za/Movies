
using Android.Widget;
using Movies.ViewModel.ViewModelUtilities;

namespace ViewModelConnectors.Android
{
    public class ConnectorEditText
    {
        public ConnectorEditText(EditText editText, ViewModelField field)
        {
            bool ignorePropertyChange = false;

            editText.TextChanged += (sender, args) =>
            {
                try
                {
                    ignorePropertyChange = true;
                    field.Value = editText.Text;
                }
                finally
                {
                    ignorePropertyChange = false;
                }
            };

            field.PropertyChanged += (sender, args) =>
            {
                if (!ignorePropertyChange)
                {
                    if (args.PropertyName == nameof(ViewModelField.Value))
                        editText.Text = field.Value;
                }
            };

            editText.Text = field.Value;
        }
    }
}