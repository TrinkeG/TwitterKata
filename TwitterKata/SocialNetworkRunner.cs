using System.Threading;

namespace TwitterKata
{
    public class SocialNetworkRunner
    {
        private readonly TwitterConsole _console;

        public SocialNetworkRunner(TwitterConsole console)
        {
            _console = console;
        }

        public void Run()
        {
            var applicationInUse=true;
            while (applicationInUse)
            {
                _console.Write(">");
                var incomingString = _console.ReadLine();
                if (incomingString!=null && incomingString.Contains("Quit"))
                    applicationInUse=false;
            }
        }
    }
}