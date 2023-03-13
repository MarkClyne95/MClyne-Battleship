using Xunit;
using Xunit.Abstractions;

namespace Battleship.Test
{
    public class ExampleTest
    {
        [Fact]
        public void TestPlay()
        {
            var ships = new[] { "3:2,3:5", "4:4,8:4" };
            var guesses = new[] { "7:0", "3:3", "3:2", "3:4", "3:0", "3:5", "4:4", "5:4", "7:3", "6:4", "7:4", "8:4" };
            Game.Play(ships, guesses).Should().Be(2); //assert the correct amount that it *should* be.
        }
    }
}