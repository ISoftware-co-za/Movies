namespace Movies.ViewModel.ViewModelUtilities
{
    public interface IValidator
    {
        bool Valid { get; }

        string InvalidMessage { get; }

        void Validate(string value);
    }
}
