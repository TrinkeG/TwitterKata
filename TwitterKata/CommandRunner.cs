﻿namespace TwitterKata
{
    public class CommandRunner
    {
        private CommandParser _commandParser;

        public CommandRunner()
        {
            
        }
        public CommandRunner(CommandParser commandParser)
        {
            _commandParser = commandParser;
        }

        public virtual void ProcessCommand(string commandInput)
        {
           var command =  _commandParser.ParseCommand(commandInput);
           command.Execute();
        }
    }
}