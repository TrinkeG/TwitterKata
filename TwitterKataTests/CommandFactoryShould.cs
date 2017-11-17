using Moq;
using NUnit.Framework;
using TwitterKata;

namespace TwitterKataTests
{
    [TestFixture]
    public class CommandParserShould
    {
        private Mock<CommandFactory> _commandFactory;

        [SetUp]
        public void SetUp()
        {
            _commandFactory = new Mock<CommandFactory>();
        }

        [Test]
        public void Pass_tokens_to_factory_when_user_makes_a_post()
        {
            var parser = new CommandParser(_commandFactory.Object);

            parser.ParseCommand("Bob -> Hi guys");
            
            _commandFactory.Verify(commandFactory => commandFactory.CreateCommand("Bob","->","Hi guys"));
        }
    }
}