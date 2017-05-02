using System;

namespace Movies.ViewModel.ViewModelUtilities
{
    public class ValidatorRequired : IValidator
    {
        public bool Valid { get; private set; }

        public string InvalidMessage { get; private set; }

        public void Validate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Valid = false;
                InvalidMessage = "Value is required.";
            }
            else
            {
                Valid = true;
                InvalidMessage = "";
            }
        }
    }
}
