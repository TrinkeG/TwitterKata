﻿namespace TwitterKata.Commands
{
    public class CommandFactory
    {

        public virtual Command CreateCommand(string userName, string command, string argument)
        {
            if(command.Equals("->"))
                return new PostCommand();
            return new ReadCommand();
        }
    }
}