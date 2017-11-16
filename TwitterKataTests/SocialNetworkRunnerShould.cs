using System;
using Moq;
using TwitterKata;
using Xunit;

namespace TwitterKataTests
{
    public class SocialNetworkRunnerShould
    {
        [Fact]
        public void write_a_prompt_to_the_console()
        {
            var console =  new Mock<TwitterConsole>();
            var socialNetworkRunner = new SocialNetworkRunner(console.Object);

            socialNetworkRunner.Run();

            console.Verify(c => c.Write(">"));
        }

	[Fact]
        public void Read_inputs_from_console()
        {
            var console = new Mock<TwitterConsole>();
            var socialNetworkRunner = new SocialNetworkRunner(console.Object);
            console.SetupSequence(c => c.ReadInput())
                .Returns("Alice -> I love the weather today")
                .Returns("Alice");

            socialNetworkRunner.Run();

            console.Verify(c => c.ReadInput());
        }
    }
}