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

        public virtual void ParseCommand(string command)
        {
            var tokens = command.Split(" ");
            _commandFactoryObject.CreateCommand(tokens);
        }
    }
}