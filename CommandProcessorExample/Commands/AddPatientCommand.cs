using CommandProcessorExample.Models;

namespace CommandProcessorExample.Commands
{
    public class AddPatientCommand : IUndoRedoCommand
    {
        private readonly MainModel mainModel;

        private Patient newPatient;

        public AddPatientCommand(MainModel mainModel)
        {
            this.mainModel = mainModel;
        }

        public bool CanDo()
        {
            return true;
        }

        public void Do()
        {
            newPatient = new Patient();
            mainModel.Patients.Add(newPatient);
        }

        public void Undo()
        {
            mainModel.Patients.Remove(newPatient);
        }

        public void Redo()
        {
            mainModel.Patients.Add(newPatient);
        }
    }
}