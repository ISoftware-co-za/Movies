using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Movies.ViewModel;
using ViewModelConnectors.Android;
using Movies.ViewModel.PageSearch;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Movies.View.Android
{
    [Activity(Label = "Movie Search", MainLauncher = true, Icon = "@drawable/icon")]
    public class ActivitySearch : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ViewModelState.Initialise(new NavigationService(this), new DeviceIntegration(this));

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Search";

            ViewModelSearch viewModel = new ViewModelSearch();
            EditText searchTerm = FindViewById<EditText>(Resource.Id.searchTerm);

            new ConnectorEditText(searchTerm, viewModel.SearchTerm);
            _connectorListView = new ConnectorListView<ListItemMovie>(this, FindViewById<ListView>(Resource.Id.searchResults), viewModel, nameof(ViewModelSearch.SearchResults), nameof(ViewModelSearch.TappedSearchResult),
                (item) => Resource.Layout.TemplateListItemMovie,
                (context, movie, view, parent) =>
                {
                    if (view == null)
                    {
                        LayoutInflater layoutInflator = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;

                        view = layoutInflator.Inflate(Resource.Layout.TemplateListItemMovie, parent, false);
                    }

                    view.FindViewById<TextView>(Resource.Id.listItemMovieTitle).Text = movie.Title;
                    view.FindViewById<TextView>(Resource.Id.listItemMovieYearAndGenre).Text = movie.YearAndGenre;

                    return view;
                });

            searchTerm.EditorAction += (sender, args) =>
            {
                viewModel.CommandSearch.Execute(null);
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        private ConnectorListView<ListItemMovie> _connectorListView;
    }
}