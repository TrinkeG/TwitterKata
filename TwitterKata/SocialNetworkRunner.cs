using System.Threading;

namespace TwitterKata
{
    public class SocialNetworkRunner
    {
        private readonly TwitterConsole _console;
        private readonly CommandRunner _commandRunner;

        public SocialNetworkRunner(TwitterConsole console, CommandRunner commandRunner)
        {
            _console = console;
            _commandRunner = commandRunner;
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
                    _commandRunner.ProcessCommand(userInput);
            }
        }

        private static bool UserWantsToQuit(string incomingString)
        {
            return incomingString!=null && incomingString.Contains("Quit");
        }
    }
}