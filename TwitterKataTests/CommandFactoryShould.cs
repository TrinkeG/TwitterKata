using NUnit.Framework;
using TwitterKata;
using TwitterKata.Commands;

namespace TwitterKataTests
{
    [TestFixture]
    public class CommandFactoryShould
    {
        [Test]
        public void Create_a_post_command()
        {
            var commandFactory=new CommandFactory();

            Assert.IsInstanceOf(typeof(PostCommand),commandFactory.CreateCommand("Bob", "->", "Hi guys"));
        }
    }
}