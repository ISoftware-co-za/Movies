using UIKit;

namespace Movies.View.iOS
{
    public static class Style
    {
        static Style()
        {
            BackgroundColor = UIColor.FromRGB(235, 235, 235);
        }

        public static void Initialise()
        {
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(0, 0, 255);

            UITextAttributes textAttributes = new UITextAttributes();

            textAttributes.TextColor = UIColor.FromRGB(255, 255, 255);

            UINavigationBar.Appearance.SetTitleTextAttributes(textAttributes);

            UITableView.Appearance.BackgroundColor = BackgroundColor;
            UITableViewCell.Appearance.BackgroundColor = BackgroundColor;
            UITextView.Appearance.BackgroundColor = BackgroundColor;
        }

        public static void ApplyRootView(UIView rootView)
        {
            rootView.BackgroundColor = BackgroundColor;
        }

        public static void ApplyMovieAttributeLabel(UILabel label)
        {
            label.TextColor = UIColor.FromRGB(160, 160, 150);
            label.Font = UIFont.SystemFontOfSize(10);
        }

        public static void ApplyMovieAttributeValue(UITextView label)
        {
            label.TextColor = UIColor.FromRGB(0, 0, 0);
            label.Font = UIFont.SystemFontOfSize(12);
        }

        private static readonly UIColor BackgroundColor;
    }
}
