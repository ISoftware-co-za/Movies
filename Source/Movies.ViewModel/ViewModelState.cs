namespace Movies.ViewModel
{
    public static class ViewModelState
    {
        public static INavigationService NavigationService { get; private set; }

        public static IDeviceIntegration DeviceIntegration { get; private set; }

        public static string SelectedMovieIMDB { get; set; }

        public static void Initialise(INavigationService navigationService, IDeviceIntegration deviceIntegration)
        {
            if (!_initialise)
            {
                NavigationService = navigationService;
                DeviceIntegration = deviceIntegration;
                _initialise = true;
            }
        }

        private static bool _initialise;
    }
}
