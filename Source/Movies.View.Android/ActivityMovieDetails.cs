using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Movies.ViewModel;
using Movies.ViewModel.PageMovieDetails;
using ViewModelConnectors.Android;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Movies.View.Android
{
    [Activity(Label = "Movie Details")]
    public class ActivityMovieDetails : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ViewModelState.Initialise(new NavigationService(this), new DeviceIntegration(this));

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MovieDetails);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            ViewModelMovieDetails viewModel = new ViewModelMovieDetails();

            viewModel.Initialise();

            SupportActionBar.Title = viewModel.Title;
            viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(ViewModelMovieDetails.Title))
                    SupportActionBar.Title = viewModel.Title;
            };

            new ConnectorImageView(FindViewById<ImageView>(Resource.Id.poster), viewModel, nameof(ViewModelMovieDetails.PosterURL));
            new ConnectorListView<ListItemMovieAttributeBase>(this, FindViewById<ListView>(Resource.Id.attributes), viewModel, nameof(ViewModelMovieDetails.Attributes), null,
                (item) =>
                {
                    if (item is ListItemMovieAttributeLabel)
                        return Resource.Layout.TemplateListItemAttributeLabel;
                    return Resource.Layout.TemplateListItemAttributeValue;
                },
                (context, item, view, parent) =>
                {
                    LayoutInflater layoutInflator = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;

                    if (item is ListItemMovieAttributeLabel)
                    {
                        ListItemMovieAttributeLabel label = (ListItemMovieAttributeLabel)item;

                        view = layoutInflator.Inflate(Resource.Layout.TemplateListItemAttributeLabel, parent, false);
                        view.FindViewById<TextView>(Resource.Id.listItemMovieAttributeLabel).Text = label.Label;
                    }
                    else
                    {
                        ListItemMovieAttributeValue value = item as ListItemMovieAttributeValue;
                        view = layoutInflator.Inflate(Resource.Layout.TemplateListItemAttributeValue, parent, false);

                        view.FindViewById<TextView>(Resource.Id.listItemMovieAttributeValue).Text = value.Value;
                    }

                    return view;
                });
            new ConnectorTextView(FindViewById<TextView>(Resource.Id.plot), viewModel, nameof(ViewModelMovieDetails.Plot));
            new ConnectorButton(FindViewById<Button>(Resource.Id.imdbWebsite), viewModel.CommandBrowseToMovie);
        }
    }
}