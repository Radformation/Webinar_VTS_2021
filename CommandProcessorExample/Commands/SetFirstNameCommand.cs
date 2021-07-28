using CommandProcessorExample.Models;

namespace CommandProcessorExample.Commands
{
    public class SetFirstNameCommand : IUndoRedoCommand
    {
        private readonly Patient patient;
        private readonly string newFirstName;

        private string oldFirstName;

        public SetFirstNameCommand(Patient patient, string newFirstName)
        {
            this.patient = patient;
            this.newFirstName = newFirstName;
        }

        public bool CanDo()
        {
            return patient.FirstName != newFirstName;
        }

        public void Do()
        {
            oldFirstName = patient.FirstName;
            patient.FirstName = newFirstName;
        }

        public void Undo()
        {
            patient.FirstName = oldFirstName;
        }

        public void Redo()
        {
            patient.FirstName = newFirstName;
        }
    }
}