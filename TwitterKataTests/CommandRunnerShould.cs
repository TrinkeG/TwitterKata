using System.Globalization;
using Moq;
using NUnit.Framework;
using TwitterKata;
using TwitterKata.Commands;

namespace TwitterKataTests
{
    [TestFixture]
    public class CommandRunnerShould
    {
        private Mock<CommandParser> _commandParser;
        private Mock<Command> _commandMock;
        private CommandRunner _commandRunner;
        private const string AlicePostInput = "Alice -> I love the weather today";
        private const string AliceReadInput = "Alice";

        [SetUp]
        public void SetUp()
        {
            _commandMock = new Mock<Command>();
            _commandParser = new Mock<CommandParser>();
            _commandRunner = new CommandRunner(_commandParser.Object);
            _commandParser.Setup(commandParser => commandParser.ParseCommand(It.IsAny<string>()))
                .Returns(_commandMock.Object);
        }

        [TestCase(AlicePostInput)]
        [TestCase(AliceReadInput)]
        public void Send_user_input_to_be_parsed(string userInput)
        {

            _commandRunner.ProcessCommand(userInput);

            _commandParser.Verify(commandParser => commandParser.ParseCommand(userInput));
        }

        [Test]
        public void Execute_a_Command()
        {
            
            _commandRunner.ProcessCommand(AlicePostInput);

            _commandMock.Verify(postCommand => postCommand.Execute());
        }

    }
}