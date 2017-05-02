using System;
using Movies.ViewModel.PageMovieDetails;
using UIKit;
using ViewModelConnectors.iOS;

namespace Movies.View.iOS
{
    public partial class ViewControllerMovieDetails : UIViewController
    {
        public ViewControllerMovieDetails (IntPtr handle) : base (handle)
        {
            _viewModel = new ViewModelMovieDetails();
            _viewModel.Initialise();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            Style.ApplyRootView(View);

            new ConnectorUIImageView(Poster, _viewModel, nameof(ViewModelMovieDetails.PosterURL));
            new ConnectorUITableView<ListItemMovieAttributeBase>(MovieAttributes, UITableViewCellStyle.Default, 20, _viewModel, nameof(ViewModelMovieDetails.Attributes), null, (item, cell) =>
            {
                if (item is ListItemMovieAttributeLabel)
                {
                    ListItemMovieAttributeLabel label = (ListItemMovieAttributeLabel) item;

                    cell.TextLabel.Text = label.Label;
                    Style.ApplyMovieAttributeLabel(cell.TextLabel);
                }
                else
                {
                    ListItemMovieAttributeValue value = (ListItemMovieAttributeValue)item;

                    cell.TextLabel.Text = value.Value;
                }
            });
            new ConnectorUITextView(Plot, _viewModel, nameof(ViewModelMovieDetails.Plot));
            new ConnectorUIButton(IMDBWebsite, _viewModel.CommandBrowseToMovie);
        }

        private readonly ViewModelMovieDetails _viewModel;
    }
}