using System;
using Android.Content;
using Movies.ViewModel;

namespace Movies.View.Android
{
    public class DeviceIntegration : IDeviceIntegration
    {
        public DeviceIntegration(Context context)
        {
            _context = context;
        }

        public void BrowseToURL(string url)
        {
            Intent intent = new Intent(Intent.ActionView);
            intent.SetData(global::Android.Net.Uri.Parse(url));

            _context.StartActivity(intent);
        }

        private readonly Context _context;
    }
}