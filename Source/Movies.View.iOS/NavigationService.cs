using System;
using Movies.ViewModel;
using UIKit;

namespace Movies.View.iOS
{
    public class NavigationService : INavigationService
    {
        public NavigationService(UINavigationController navigationController)
        {
            _navigationController = navigationController;
        }

        public void NavigateTo(NavigationDestination destination)
        {
            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);

            if (destination == NavigationDestination.MovieDetails)
            {
                ViewControllerMovieDetails viewController = storyboard.InstantiateViewController("ViewControllerMovieDetails") as ViewControllerMovieDetails;

                _navigationController.PushViewController(viewController, true);
            }
        }

        private readonly UINavigationController _navigationController;
    }
}
