using GalaSoft.MvvmLight;

namespace CommandProcessorExample.Models
{
    public class Patient : ObservableObject
    {
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set => Set(nameof(FirstName), ref firstName, value);
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set => Set(nameof(LastName), ref lastName, value);
        }
    }
}
