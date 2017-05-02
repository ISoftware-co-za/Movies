using System.Collections.Generic;

namespace Movies.ViewModel.ViewModelUtilities
{
    public class ViewModelField : PropertyChangeNotifier
    {
        public string Value
        {
            get { return _value; }
            set
            {
                if (SetField(ref _value, value))
                {
                    _value = value;
                    ValidateField();
                }
            }
        }
        private string _value;

        public bool Valid
        {
            get => _valid;
            set => SetField( ref _valid, value);
        }

        public string InvalidMessage { get; set; }

        public ViewModelField(IEnumerable<IValidator> validators = null)
        {
            _validators = validators;
        }

        private void ValidateField()
        {
            bool valid = true;

            if (_validators != null)
            {
                foreach (var validator in _validators)
                {
                    validator.Validate(Value);
                    if (!validator.Valid)
                    {
                        valid = false;
                        InvalidMessage = validator.InvalidMessage;
                        break;
                    }
                }
            }

            Valid = valid;
            if (Valid)
                InvalidMessage = "";
        }

        private readonly IEnumerable<IValidator> _validators;
        private bool _valid;
    }
}
