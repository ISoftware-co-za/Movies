using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Model;
using Movies.ViewModel.ViewModelUtilities;

namespace Movies.ViewModel.PageSearch
{
    public class CommandSearch : ViewModelCommandAsync
    {
        public CommandSearch(ViewModelSearch viewModel)
        {
            _viewModel = viewModel;
        }

        public override async Task PerformAsync()
        {
            OMDBSearch movieSearch = new OMDBSearch();

            List<MovieSearchResultMovie> locatedMovies = await movieSearch.Search(_viewModel.SearchTerm.Value);

            // ToDo: Sort the results here

            List<ListItemMovie> movies = new List<ListItemMovie>();

            foreach (var locatedMovie in locatedMovies)
            {
                movies.Add(new ListItemMovie
                {
                    IMDBID = locatedMovie.IMDBID,
                    Title = locatedMovie.Title,
                    YearAndGenre = $"{locatedMovie.Year} {locatedMovie.Type}"
                });
            }

            _viewModel.SearchResults = movies;
        }

        private readonly ViewModelSearch _viewModel;
    }
}
