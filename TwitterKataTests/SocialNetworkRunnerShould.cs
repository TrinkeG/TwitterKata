using System;
using Moq;
using NUnit.Framework;
using TwitterKata;

namespace TwitterKataTests
{
    [TestFixture]
    public class SocialNetworkRunnerShould
    {
        private Mock<TwitterConsole> _console;
        private Mock<CommandRunner> _commandRunner;
        private SocialNetworkRunner _socialNetworkRunner;
        private const string QuitInput = "Quit";
        private const string AlicePostInput = "Alice -> I love the weather today";
        private const string AliceReadInput = "Alice";

        [SetUp]
        public void SetUp()
        {
            _commandRunner  = new Mock<CommandRunner>();
            _console = new Mock<TwitterConsole>();
            _socialNetworkRunner = new SocialNetworkRunner(_console.Object,_commandRunner.Object);
        }

        [Test]
        public void Write_a_prompt_to_the_console()
        {
            _console.Setup(console => console.ReadLine()).Returns(QuitInput);

            _socialNetworkRunner.Run();

            _console.Verify(c => c.Write(">"));
        }
        
        [Test]
        public void Read_user_lines_from_console_until_quit_typed()
        {
            _console.SetupSequence(console => console.ReadLine())
                .Returns(AlicePostInput)
                .Returns(AliceReadInput)
                .Returns(QuitInput);

            _socialNetworkRunner.Run();

            _console.Verify(console => console.ReadLine(),Times.Exactly(3));
        }

        [Test]
        public void Send_commands_to_be_processed()
        {
            _console.SetupSequence(console => console.ReadLine())
                .Returns(AlicePostInput)
                .Returns(QuitInput);

            _socialNetworkRunner.Run();

            _commandRunner.Verify(commandRunner => commandRunner.ProcessCommand(AlicePostInput));
        }
        
    }
}