using Windows.UI.Xaml.Controls;
using Movies.ViewModel.PageSearch;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Movies.View.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageSearch : Page
    {
        public PageSearch()
        {
            this.InitializeComponent();

            _viewModel = new ViewModelSearch();
            DataContext = _viewModel;
        }

        private void AutoSuggestBox_OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (_viewModel.CommandSearch.CanExecute(null))
                _viewModel.CommandSearch.Execute(null);
        }

        private readonly ViewModelSearch _viewModel;

        private void AutoSuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                _viewModel.SearchTerm.Value = sender.Text;
        }
    }
}
