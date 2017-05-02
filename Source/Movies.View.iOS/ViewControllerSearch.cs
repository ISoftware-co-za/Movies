using Foundation;
using System;
using Movies.ViewModel.PageSearch;
using UIKit;
using ViewModelConnectors.iOS;

namespace Movies.View.iOS
{
    public partial class ViewControllerSearch : UIViewController
    {
        public ViewControllerSearch (IntPtr handle) : base (handle)
        {
            _viewModel = new ViewModelSearch();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            Style.ApplyRootView(View);

            new ConnectorUISearchBar(SearchTerm, _viewModel.SearchTerm);

            SearchTerm.SearchButtonClicked += (sender, args) =>
            {
                _viewModel.CommandSearch.Execute(null);
            };

            new ConnectorUITableView<ListItemMovie>(SearchResults, UITableViewCellStyle.Subtitle, null, _viewModel, nameof(ViewModelSearch.SearchResults), nameof(ViewModelSearch.TappedSearchResult), (movie, cell) =>
            {
                cell.TextLabel.Text = movie.Title;
                cell.DetailTextLabel.Text = movie.YearAndGenre;
                cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            });
        }

        private readonly ViewModelSearch _viewModel;
    }
}