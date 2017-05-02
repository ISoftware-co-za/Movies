using System;
using Movies.ViewModel;

namespace Movies.View.UWP
{
    public class DeviceIntegration : IDeviceIntegration
    {
        public async void BrowseToURL(string url)
        {
            var uri = new Uri(url);
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
