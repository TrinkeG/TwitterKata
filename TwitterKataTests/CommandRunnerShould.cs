using Moq;
using NUnit.Framework;
using TwitterKata;

namespace TwitterKataTests
{
    [TestFixture]
    public class CommandRunnerShould
    {
        private Mock<CommandParser> _commandParser;
        private const string AlicePostInput = "Alice -> I love the weather today";

        [SetUp]
        public void SetUp()
        {
            _commandParser = new Mock<CommandParser>();
        }

        [Test]
        public void Send_post_input_to_be_parsed()
        {
            var commandRunner = new CommandRunner(_commandParser.Object);

            commandRunner.ProcessCommand(AlicePostInput);

            _commandParser.Verify(commandParser => commandParser.ParseCommand(AlicePostInput));
        }

    }
}