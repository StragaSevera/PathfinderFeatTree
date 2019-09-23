using NFluent;
using Xunit;

namespace PFFeatTree.Tests
{
    public class StatPrereqTests
    {
        [Fact]
        public void Can_Be_Created()
        {
            var sut = new StatPrereq(StatBlock.With().Dex(15).Wis(13).Build());

            Check.That(sut.Constraints).HasSize(2)
                .And.ContainsPair(Stat.Dex, 15)
                .And.ContainsPair(Stat.Wis, 13);
        }
    }
}