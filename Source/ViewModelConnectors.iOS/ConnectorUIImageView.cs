using System;
using System.ComponentModel;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace ViewModelConnectors.iOS
{
    public class ConnectorUIImageView 
    {
        public ConnectorUIImageView(UIImageView imageView, object viewModel, string propertyName)
        {
            PropertyInfo propertyInfo = viewModel.GetType().GetProperty(propertyName);

            if (propertyInfo == null)
                throw new Exception($"ConnectorUIImageView cannot bind to {propertyName} as it is not a property of {viewModel.GetType().FullName}.");

            if (viewModel is INotifyPropertyChanged)
            {
                INotifyPropertyChanged notifyPropertyChanged = (INotifyPropertyChanged) viewModel;

                notifyPropertyChanged.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == propertyName)
                        SetImageForPoster(imageView, viewModel, propertyInfo);
                };
            }

            SetImageForPoster(imageView, viewModel, propertyInfo);
        }

        private async void SetImageForPoster(UIImageView imageView, object viewModel, PropertyInfo propertyInfo)
        {
            string posterURL = propertyInfo.GetValue(viewModel)?.ToString();

            if (!string.IsNullOrEmpty(posterURL))
            {
                UIImage image = await LoadImage(posterURL);

                imageView.Image = image;
            }
        }

        private async Task<UIImage> LoadImage(string imageUrl)
        {
            var httpClient = new HttpClient();

            byte[] contentsTask = await httpClient.GetByteArrayAsync(imageUrl);

            return UIImage.LoadFromData(NSData.FromArray(contentsTask));
        }
    }
}
