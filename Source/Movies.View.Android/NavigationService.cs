using Android.Content;
using Movies.ViewModel;

namespace Movies.View.Android
{
    public class NavigationService : INavigationService
    {
        public NavigationService(Context context)
        {
            _context = context;
        }

        public void NavigateTo(NavigationDestination destination)
        {
            if (destination == NavigationDestination.MovieDetails)
                _context.StartActivity(typeof(ActivityMovieDetails));
            else
                _context.StartActivity(typeof(ActivitySearch));
        }

        private readonly Context _context;
    }
}