using System;
using Movies.ViewModel.ViewModelUtilities;
using UIKit;

namespace ViewModelConnectors.iOS
{
    public class ConnectorUISearchBar
    {
        public ConnectorUISearchBar(UISearchBar searchBar, ViewModelField field)
        {
            bool ignorePropertyChange = false;

            searchBar.TextChanged += (sender, args) =>
            {
                try
                {
                    ignorePropertyChange = true;
                    field.Value = args.SearchText;
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
                        searchBar.Text = field.Value;
                }
            };

            searchBar.Text = field.Value;
        }
    }
}
