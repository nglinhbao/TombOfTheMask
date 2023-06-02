using System;

namespace TombOfTheMask
{
    public class CommandInvoker
    {
        private ICommand _command;

        public CommandInvoker(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}
