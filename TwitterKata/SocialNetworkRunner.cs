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
            _console.Write(">");
        }
    }
}