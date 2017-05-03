using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace ViewModelConnectors.Android
{
    public class ConnectorListView<T>
    {
        public ConnectorListView(Context context, ListView listView, object viewModel, string listPropertyName, string selectedItemPropertyName, Func<T, int> viewTypeFunc, Func<Context, T,View, ViewGroup, View> viewSetupFunc)
        {
            PropertyInfo listPropertyInfo = viewModel.GetType().GetProperty(listPropertyName);

            if (listPropertyInfo == null)
                throw new Exception($"ConnectorListView<T> cannot bind to {listPropertyName} as it is not a property of {viewModel.GetType().FullName}.");

            var listAdapter = new ListAdapter<T>(context, viewTypeFunc, viewSetupFunc);

            if (viewModel is INotifyPropertyChanged)
            {
                INotifyPropertyChanged notifyPropertyChanged = (INotifyPropertyChanged)viewModel;

                notifyPropertyChanged.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == listPropertyName)
                        listAdapter.SetItems(listPropertyInfo.GetValue(viewModel) as List<T>);
                };
            }

            if (!string.IsNullOrEmpty(selectedItemPropertyName))
            {
                PropertyInfo selectedItemPropertyInfo = viewModel.GetType().GetProperty(selectedItemPropertyName);

                if (selectedItemPropertyInfo == null)
                    throw new Exception($"ConnectorListView<T> cannot bind to {selectedItemPropertyName} as it is not a property of {viewModel.GetType().FullName}.");

                listView.ItemClick += (sender, args) =>
                {
                    IList<T> items = listPropertyInfo.GetValue(viewModel) as IList<T>;
                    selectedItemPropertyInfo.SetValue(viewModel, items[args.Position]);
                };
            }

            IList<T> listItems = listPropertyInfo.GetValue(viewModel) as IList<T>;

            if (listItems != null && listItems.Count > 0)
                listAdapter.SetItems(listItems);
            listView.Adapter = listAdapter;
        }

        private void ListView_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}