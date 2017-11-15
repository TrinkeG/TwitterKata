using Moq;
using TwitterKata;
using Xunit;

namespace TwitterKataTests
{
    public class TwitterKataShould
    {
        //    User can post to a wall
        //    > Alice -> I love the weather today
        //    > Alice
        //    I love the weather today(5 minutes ago)
        [Fact]
        public void write_a_prompt_to_the_wall_on_startup()
        {
            var console = new Mock<TwitterConsole>();
            var runner = new SocialNetworkRunner(console.Object);

            runner.Run();

            console.Verify(c => c.Write(">"));
        }
        /*[Fact]
        public void Allow_Users_To_Post_To_Wall()
        {
            var console = new Mock<TwitterConsole>();
            var runner = new SocialNetworkRunner(console.Object);
            console.SetupSequence(c => c.ReadInput())
                .Returns("Alice -> I love the weather today")
                .Returns("Alice");

            var clock = new Mock<Clock>();
            clock.SetupSequence(c => c.Now())
                .Returns(new DateTime(2017, 11, 15, 13, 0, 0))
                .Returns(new DateTime(2017, 11, 15, 13, 5, 0));

            runner.Run();

            console.Verify(c => c.WriteLine("I love the weather today(5 minutes ago)"));
            Assert.True(true);
        }*/
    }
}
