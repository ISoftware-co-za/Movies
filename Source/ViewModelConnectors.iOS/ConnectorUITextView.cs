using System;
using System.ComponentModel;
using System.Reflection;
using UIKit;

namespace ViewModelConnectors.iOS
{
    public class ConnectorUITextView
    {
        public ConnectorUITextView(UITextView textView, object viewModel, string propertyName)
        {
            PropertyInfo propertyInfo = viewModel.GetType().GetProperty(propertyName);

            if (propertyInfo == null)
                throw new Exception($"ConnectorUITextView cannot bind to {propertyName} as it is not a property of {viewModel.GetType().FullName}.");

            if (viewModel is INotifyPropertyChanged)
            {
                INotifyPropertyChanged notifyPropertyChanged = (INotifyPropertyChanged)viewModel;

                notifyPropertyChanged.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == propertyName)
                    {
                        SetTextViewText(textView, viewModel, propertyInfo);
                    }
                };
            }

            SetTextViewText(textView, viewModel, propertyInfo);
        }

        private static void SetTextViewText(UITextView textView, object viewModel, PropertyInfo propertyInfo)
        {
            textView.Text = propertyInfo.GetValue(viewModel)?.ToString();
            textView.SizeToFit();
        }
    }
}
