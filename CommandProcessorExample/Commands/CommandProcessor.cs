using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CommandProcessorExample.Commands
{
    public class CommandProcessor
    {
        private readonly Stack<IUndoRedoCommand> undoStack;
        private readonly Stack<IUndoRedoCommand> redoStack;

        private CommandProcessor()
        {
            undoStack = new Stack<IUndoRedoCommand>();
            redoStack = new Stack<IUndoRedoCommand>();
        }

        // Use the Singleton pattern
        private static CommandProcessor instance;
        public static CommandProcessor Instance
        {
            get
            {
                if (instance == null)
                    instance = new CommandProcessor();
                return instance;
            }
        }

        public void Process(IUndoRedoCommand command)
        {
            var commandName = command.GetType().Name;

            if (command.CanDo())
            {
                try
                {
                    Debug.WriteLine($"Processing {commandName}");

                    command.Do();
                    Push(command);

                    Debug.WriteLine($"Completed {commandName}");
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Failed {commandName}: {e.Message}");
                }
            }
        }

        public void Undo()
        {
            if (CanUndo())
            {
                var command = undoStack.Pop();
                command.Undo();
                redoStack.Push(command);
            }
        }

        public void Redo()
        {
            if (CanRedo())
            {
                var command = redoStack.Pop();
                command.Redo();
                undoStack.Push(command);
            }
        }

        public bool CanUndo()
        {
            return undoStack.Any();
        }

        public bool CanRedo()
        {
            return redoStack.Any();
        }

        private void Push(IUndoRedoCommand command)
        {
            undoStack.Push(command);
            redoStack.Clear();
        }
    }
}
