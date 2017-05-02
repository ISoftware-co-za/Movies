namespace Movies.ViewModel.PageMovieDetails
{
    public class ListItemMovieAttributeValue : ListItemMovieAttributeBase
    {
        public string Value { get;}

        public ListItemMovieAttributeValue(string value)
        {
            Value = value.Trim();
        }
    }
}
