using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using CommandProcessorExample.Commands;
using CommandProcessorExample.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommandProcessorExample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainModel MainModel { get; private set; }

        public ObservableCollection<PatientViewModel> Patients { get; } =
            new ObservableCollection<PatientViewModel>();

        public ICommand UndoCommand => new RelayCommand(
            () => CommandProcessor.Instance.Undo(),
            () => CommandProcessor.Instance.CanUndo());

        public ICommand RedoCommand => new RelayCommand(
            () => CommandProcessor.Instance.Redo(),
            () => CommandProcessor.Instance.CanRedo());

        public ICommand AddPatientCommand => new RelayCommand(() =>
            CommandProcessor.Instance.Process(new AddPatientCommand(MainModel)));

        public void Initialize(MainModel mainModel)
        {
            MainModel = mainModel;

            foreach (var patient in MainModel.Patients)
            {
                var patientVm = new PatientViewModel();
                patientVm.Initialize(patient, mainModel);
                Patients.Add(patientVm);
            }

            MainModel.Patients.CollectionChanged += Patients_CollectionChanged;
        }

        private void Patients_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var patient = (Patient)e.NewItems[0];
                var index = e.NewStartingIndex;
                var patientVm = new PatientViewModel();
                patientVm.Initialize(patient, MainModel);
                Patients.Insert(index, patientVm);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var patient = (Patient)e.OldItems[0];
                var patientVm = Patients.First(p => p.Patient == patient);
                Patients.Remove(patientVm);
            }
        }
    }
}
