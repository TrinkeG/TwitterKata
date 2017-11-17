using System.Collections.Generic;
using System.Linq;

namespace TwitterKata
{
    public class CommandParser
    {
        private readonly CommandFactory _commandFactoryObject;

        public CommandParser()
        {
            
        }
        public CommandParser(CommandFactory commandFactoryObject)
        {
            _commandFactoryObject = commandFactoryObject;
        }

        public virtual void ParseCommand(string commandInput)
        {
            var tokens = commandInput.Split(" ").ToList();
            var userName = GetFirstAndRemovefromList(tokens);
            var command = GetFirstAndRemovefromList(tokens);
            var argument = string.Join(' ', tokens);

            _commandFactoryObject.CreateCommand(userName,command,argument);
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