namespace Movies.ViewModel.PageMovieDetails
{
    public class ListItemMovieAttributeLabel : ListItemMovieAttributeBase
    {
        public string Label { get; }

        public ListItemMovieAttributeLabel(string label)
        {
            Label = label;
        }
    }
}
