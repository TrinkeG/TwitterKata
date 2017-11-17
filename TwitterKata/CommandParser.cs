using System.Collections.Generic;
using System.Linq;
using TwitterKata.Commands;

namespace TwitterKata
{
    public class CommandParser
    {
        private readonly CommandFactory _commandFactory;

        public CommandParser()
        {
            
        }
        public CommandParser(CommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public virtual Command ParseCommand(string commandInput)
        {
            var tokens = commandInput.Split(" ").ToList();
            var userName = GetFirstAndRemovefromList(tokens);
            var command = GetFirstAndRemovefromList(tokens);
            var argument = string.Join(' ', tokens);

            return _commandFactory.CreateCommand(userName,command,argument);
        }

        private static string GetFirstAndRemovefromList(List<string> tokens)
        {
            var token = tokens.FirstOrDefault()??"";
            if(tokens.Count>0)
                tokens.RemoveAt(0);
            return token;
        }
    }
}