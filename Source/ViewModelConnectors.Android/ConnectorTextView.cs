using System;
using System.ComponentModel;
using System.Reflection;
using Android.Widget;

namespace ViewModelConnectors.Android
{
    public class ConnectorTextView
    {
        public ConnectorTextView(TextView editText, object viewModel, string propertyName)
        {
            PropertyInfo propertyInfo = viewModel.GetType().GetProperty(propertyName);

            if (propertyInfo == null)
                throw new Exception($"ConnectorTextView cannot bind to {propertyName} as it is not a property of {viewModel.GetType().FullName}.");

            if (viewModel is INotifyPropertyChanged)
            {
                INotifyPropertyChanged notifyPropertyChanged = (INotifyPropertyChanged)viewModel;

                notifyPropertyChanged.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == propertyName)
                        editText.Text = propertyInfo.GetValue(viewModel)?.ToString();
                };
            }
        }
    }
}