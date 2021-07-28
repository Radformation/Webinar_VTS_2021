namespace CommandProcessorExample.Commands
{
    public interface IUndoRedoCommand
    {
        bool CanDo();
        void Do();
        void Undo();
        void Redo();
    }
}