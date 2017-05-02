using System;
using Windows.UI.Xaml.Controls;
using Movies.ViewModel;

namespace Movies.View.UWP
{
    public class NavigationService : INavigationService
    {
        public NavigationService(Frame rootFrame)
        {
            _rootFrame = rootFrame;
        }

        public void NavigateTo(NavigationDestination destination)
        {
            if (destination == NavigationDestination.Search)
                _rootFrame.Navigate(typeof(PageSearch));
            else if (destination == NavigationDestination.MovieDetails)
                _rootFrame.Navigate(typeof(PageMovieDetails));
        }

        public void NavigateBack()
        {
            if (_rootFrame.CanGoBack)
                _rootFrame.GoBack();
        }

        private readonly Frame _rootFrame;
    }
}
