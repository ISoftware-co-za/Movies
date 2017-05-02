
using Movies.ViewModel.ViewModelUtilities;

namespace Movies.ViewModel.PageMovieDetails
{
    public class CommandBrowseToMovie : ViewModelCommand
    {
        public CommandBrowseToMovie(ViewModelMovieDetails viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(ViewModelMovieDetails.Imdburl))
                    SetEnabled();
            };
            SetEnabled();
        }

        public override void Perform()
        {
            ViewModelState.DeviceIntegration.BrowseToURL(_viewModel.Imdburl);
        }

        private void SetEnabled()
        {
            Enabled = !string.IsNullOrEmpty(_viewModel.Imdburl);
        }

        private readonly ViewModelMovieDetails _viewModel;

    }
}
