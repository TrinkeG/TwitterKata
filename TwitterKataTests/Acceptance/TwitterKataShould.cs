using System;
using Moq;
using NUnit.Framework;
using TwitterKata;

namespace TwitterKataTests.Acceptance
{
    [TestFixture]
    public class TwitterKataShould
    {
        private SocialNetworkRunner _runner;
        private Mock<TwitterConsole> _console;
        private CommandParser _commandParser;
        private CommandFactory _commandFactory;

        [SetUp]
        public void SetUp()
        {
            _commandFactory = new CommandFactory();
            _commandParser = new CommandParser(_commandFactory);
            _console = new Mock<TwitterConsole>();
            _runner = new SocialNetworkRunner(_console.Object,_commandParser);
        }

        [Test]
        public void Write_a_prompt_to_the_wall_on_startup()
        {
            _console.Setup(c => c.ReadLine()).Returns("Quit");

            _runner.Run();

            _console.Verify(c => c.Write(">"));
        }

        [Ignore("Acceptance-WIP")]
        [Test]
        public void Allow_Users_To_Post_To_Wall()
        {
            _console.SetupSequence(c => c.ReadLine())
                .Returns("Alice -> I love the weather today")
                .Returns("Alice")
                .Returns("Quit");

            var clock = new Mock<Clock>();
            clock.SetupSequence(c => c.Now())
                .Returns(new DateTime(2017, 11, 15, 13, 0, 0))
                .Returns(new DateTime(2017, 11, 15, 13, 5, 0));

            _runner.Run();

            _console.Verify(c => c.WriteLine("I love the weather today(5 minutes ago)"));
            Assert.True(true);
        }
    }
}
