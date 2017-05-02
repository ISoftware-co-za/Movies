using Foundation;
using Movies.ViewModel;
using UIKit;

namespace Movies.View.iOS
{
    public class DeviceIntegration : IDeviceIntegration
    {
        public void BrowseToURL(string url)
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl(url));
        }
    }
}
