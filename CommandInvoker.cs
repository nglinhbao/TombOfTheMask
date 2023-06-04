using System;

namespace TombOfTheMask
{
    // Represents a CommandInvoker object
    public class CommandInvoker
    {
        private ICommand _command;

        // Constructor that takes an ICommand object as a parameter
        public CommandInvoker(ICommand command)
        {
            _command = command;
        }

        // Executes the command by calling its Execute method
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}
