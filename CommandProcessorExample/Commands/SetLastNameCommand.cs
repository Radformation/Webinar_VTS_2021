using CommandProcessorExample.Models;

namespace CommandProcessorExample.Commands
{
    public class SetLastNameCommand : IUndoRedoCommand
    {
        private readonly Patient patient;
        private readonly string newLastName;

        private string oldLastName;

        public SetLastNameCommand(Patient patient, string newLastName)
        {
            this.patient = patient;
            this.newLastName = newLastName;
        }

        public bool CanDo()
        {
            return patient.LastName != newLastName;
        }

        public void Do()
        {
            oldLastName = patient.LastName;
            patient.LastName = newLastName;
        }

        public void Undo()
        {
            patient.LastName = oldLastName;
        }

        public void Redo()
        {
            patient.LastName = newLastName;
        }
    }
}