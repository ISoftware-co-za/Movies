using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UIKit;

namespace ViewModelConnectors.iOS
{
    public class ConnectorUITableView<T>
    {
        public ConnectorUITableView(UITableView tableView, UITableViewCellStyle cellStyle, nfloat? rowHeight, object viewModel, string listPropertyName, string selectedItemPropertyName, Action<T, UITableViewCell> setupAction)
        {
            _tableView = tableView;

            PropertyInfo listPropertyInfo = viewModel.GetType().GetProperty(listPropertyName);

            if (listPropertyInfo == null)
                throw new Exception($"ConnectorUITableView<T> cannot bind to {listPropertyName} as it is not a property of {viewModel.GetType().FullName}.");

            if (viewModel is INotifyPropertyChanged)
            {
                INotifyPropertyChanged notifyPropertyChanged = (INotifyPropertyChanged) viewModel;

                notifyPropertyChanged.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == listPropertyName)
                    {
                        _tableViewSource.SetItems(listPropertyInfo.GetValue(viewModel) as List<T>);
                        _tableView.ReloadData();
                    }
                };
            }

            _tableViewSource = new ListUITableViewSource<T>(cellStyle, rowHeight, setupAction);
            _tableViewSource.SetItems(listPropertyInfo.GetValue(viewModel) as List<T>);
            tableView.Source = _tableViewSource;

            if (!string.IsNullOrEmpty(selectedItemPropertyName))
            {
                PropertyInfo selectedItemPropertyInfo = viewModel.GetType().GetProperty(selectedItemPropertyName);

                if (selectedItemPropertyInfo == null)
                    throw new Exception($"ConnectorUITableView<T> cannot bind to {selectedItemPropertyName} as it is not a property of {viewModel.GetType().FullName}.");

                _tableViewSource.RowTapped += (sender, args) =>
                {
                    selectedItemPropertyInfo.SetValue(viewModel, args.SelectedItem);
                };
            }
        }

        private readonly UITableView _tableView;
        private readonly ListUITableViewSource<T> _tableViewSource;
    }
}
