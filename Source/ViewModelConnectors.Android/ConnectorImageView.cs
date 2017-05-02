using System;
using System.ComponentModel;
using System.Reflection;
using Android.Graphics;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;

namespace ViewModelConnectors.Android
{
    public class ConnectorImageView
    { 
        public ConnectorImageView(ImageView imageView, object viewModel, string propertyName)
        {
            PropertyInfo listPropertyInfo = viewModel.GetType().GetProperty(propertyName);

            if (listPropertyInfo == null)
                throw new Exception($"ConnectorImageView cannot bind to {propertyName} as it is not a property of {viewModel.GetType().FullName}.");

            if (viewModel is INotifyPropertyChanged)
            {
                INotifyPropertyChanged notifyPropertyChanged = (INotifyPropertyChanged)viewModel;

                notifyPropertyChanged.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == propertyName)
                        SetImageViewURL(imageView, viewModel, listPropertyInfo);
                };
            }

            SetImageViewURL(imageView, viewModel, listPropertyInfo);
        }

        private static async Task SetImageViewURL(ImageView imageView, object viewModel, PropertyInfo listPropertyInfo)
        {
            string posterURL = listPropertyInfo.GetValue(viewModel)?.ToString();

            if (!string.IsNullOrEmpty(posterURL))
            {
                using (var httpClient = new HttpClient())
                {
                    var imageBytes = await httpClient.GetByteArrayAsync(posterURL);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        var imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);

                        imageView.SetImageBitmap(imageBitmap);
                    }
                }
            }
        }
    }
}