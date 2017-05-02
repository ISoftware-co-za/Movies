using System.Collections.Generic;

using Movies.ViewModel.ViewModelUtilities;

namespace Movies.ViewModel.PageSearch
{
    public class ViewModelSearch : ViewModelBase
    {
        public ViewModelField SearchTerm { get; }

        public List<ListItemMovie> SearchResults
        {
            get => _searchResults;
            set => SetField( ref _searchResults, value);
        }
        private List<ListItemMovie> _searchResults;

        public ListItemMovie TappedSearchResult
        {
            get { return _tappedSearchResult; }
            set
            {
                if (SetField( ref _tappedSearchResult, value))
                {
                    ViewModelState.SelectedMovieIMDB = value.IMDBID;
                    ViewModelState.NavigationService.NavigateTo(NavigationDestination.MovieDetails);
                    _tappedSearchResult = null;
                }
            }
        }
        private ListItemMovie _tappedSearchResult;

        public ViewModelCommandBase CommandSearch { get; }

        public ViewModelSearch()
        {
            SearchTerm = new ViewModelField(new List<IValidator>{new ValidatorRequired()});
            SearchTerm.PropertyChanged += (sender, args) =>
            {
                CommandSearch.Enabled = SearchTerm.Valid;
            };

            CommandSearch = new CommandSearch(this);
        }
    }
}
