using System.ComponentModel;
using System.Windows.Input;
using CommandProcessorExample.Commands;
using CommandProcessorExample.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommandProcessorExample.ViewModels
{
    public class PatientViewModel : ViewModelBase
    {
        public Patient Patient { get; private set; }
        public MainModel MainModel { get; private set; }

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

        public ICommand SetFirstNameCommand => new RelayCommand(() =>
            CommandProcessor.Instance.Process(new SetFirstNameCommand(Patient, FirstName)));

        public ICommand SetLastNameCommand => new RelayCommand(() =>
            CommandProcessor.Instance.Process(new SetLastNameCommand(Patient, LastName)));

        public ICommand RemovePatientCommand => new RelayCommand(() =>
            CommandProcessor.Instance.Process(new RemovePatientCommand(MainModel, Patient)));

        public void Initialize(Patient patient, MainModel mainModel)
        {
            Patient = patient;
            MainModel = mainModel;

            UpdateFirstName();
            UpdateLastName();

            Patient.PropertyChanged += Patient_PropertyChanged;
        }

        private void UpdateFirstName() => FirstName = Patient.FirstName;
        private void UpdateLastName() => LastName = Patient.LastName;

        private void Patient_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Patient.FirstName): UpdateFirstName(); break;
                case nameof(Patient.LastName): UpdateLastName(); break;
            }
        }
    }
}