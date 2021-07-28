using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace CommandProcessorExample.Models
{
    public class MainModel : ObservableObject
    {
        public ObservableCollection<Patient> Patients { get; } =
            new ObservableCollection<Patient>();
    }
}
