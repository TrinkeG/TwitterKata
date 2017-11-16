using System.Threading;

namespace TwitterKata
{
    public class SocialNetworkRunner
    {
        private readonly TwitterConsole _console;
        private readonly CommandParser _commandParser;

        public SocialNetworkRunner(TwitterConsole console, CommandParser commandParser)
        {
            _console = console;
            _commandParser = commandParser;
        }

        public void Run()
        {
            var applicationInUse=true;
            while (applicationInUse)
            {
                _console.Write(">");
                var userInput = _console.ReadLine();
                if (UserWantsToQuit(userInput))
                    applicationInUse=false;
                else
                    _commandParser.ParseCommand(userInput);
            }
        }

        private static bool UserWantsToQuit(string incomingString)
        {
            return incomingString!=null && incomingString.Contains("Quit");
        }
    }
}