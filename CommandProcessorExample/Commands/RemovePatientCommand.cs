using CommandProcessorExample.Models;

namespace CommandProcessorExample.Commands
{
    public class RemovePatientCommand : IUndoRedoCommand
    {
        private readonly MainModel mainModel;
        private readonly Patient patient;

        private int index;

        public RemovePatientCommand(MainModel mainModel, Patient patient)
        {
            this.mainModel = mainModel;
            this.patient = patient;
        }

        public bool CanDo()
        {
            return true;
        }

        public void Do()
        {
            index = mainModel.Patients.IndexOf(patient);
            mainModel.Patients.RemoveAt(index);
        }

        public void Undo()
        {
            mainModel.Patients.Insert(index, patient);
        }

        public void Redo()
        {
            mainModel.Patients.RemoveAt(index);
        }
    }
}