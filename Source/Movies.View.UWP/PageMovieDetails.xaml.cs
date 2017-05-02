using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Movies.ViewModel.PageMovieDetails;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Movies.View.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageMovieDetails : Page
    {
        public PageMovieDetails()
        {
            InitializeComponent();

            ItemTemplateSelectorMovieAttributeType.LabelTemplate = Resources["ListItemMovieAttributeLabel"] as DataTemplate;
            ItemTemplateSelectorMovieAttributeType.ValueTemplate = Resources["ListItemMovieAttributeValue"] as DataTemplate;

            ViewModelMovieDetails viewModel = new ViewModelMovieDetails();

            DataContext = viewModel;
            viewModel.Initialise();
        }
    }
}
