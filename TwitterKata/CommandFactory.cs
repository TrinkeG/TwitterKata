﻿using TwitterKata.Commands;

namespace TwitterKata
{
    public class CommandFactory
    {

        public virtual Command CreateCommand(string userName, string command, string argument)
        {
            return new PostCommand();
        }
    }
}