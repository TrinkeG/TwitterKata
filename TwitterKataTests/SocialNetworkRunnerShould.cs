﻿using System;
using Moq;
using NUnit.Framework;
using TwitterKata;

namespace TwitterKataTests
{
    [TestFixture]
    public class SocialNetworkRunnerShould
    {
        private Mock<TwitterConsole> _console;
        private Mock<CommandParser> _commandParser;
        private SocialNetworkRunner _socialNetworkRunner;

        [SetUp]
        public void SetUp()
        {
            _console = new Mock<TwitterConsole>();
            _commandParser = new Mock<CommandParser>();
            _socialNetworkRunner = new SocialNetworkRunner(_console.Object,_commandParser.Object);
        }

        [Test]
        public void Write_a_prompt_to_the_console()
        {
            _console.Setup(console => console.ReadLine()).Returns("Quit");

            _socialNetworkRunner.Run();

            _console.Verify(c => c.Write(">"));
        }
        
        [Test]
        public void Read_user_lines_from_console_until_quit_typed()
        {
            _console.SetupSequence(console => console.ReadLine())
                .Returns("Alice -> I love the weather today")
                .Returns("Alice")
                .Returns("Quit");

            _socialNetworkRunner.Run();

            _console.Verify(console => console.ReadLine(),Times.Exactly(3));
        }

        [Test]
        public void Send_commands_to_be_parsed()
        {
            _console.SetupSequence(console => console.ReadLine())
                .Returns("Alice -> I love the weather today")
                .Returns("Quit");

            _socialNetworkRunner.Run();

            _commandParser.Verify(commandParser => commandParser.ParseCommand("Alice -> I love the weather today"));
        }
    }
}