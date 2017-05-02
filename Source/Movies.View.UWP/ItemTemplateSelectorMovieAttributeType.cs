using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Movies.ViewModel.PageMovieDetails;

namespace Movies.View.UWP
{
    internal class ItemTemplateSelectorMovieAttributeType : DataTemplateSelector
    {
        public static DataTemplate LabelTemplate { get; set; }

        public static DataTemplate ValueTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is ListItemMovieAttributeLabel)
                return LabelTemplate;
            return ValueTemplate;
        }
    }
}
