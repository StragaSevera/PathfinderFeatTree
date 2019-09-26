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

        [Fact]
        public void Can_Check_That_Character_Satisfies()
        {
            var character = new Character(StatBlock.With().Default().Str(13).Dex(15).Wis(10).Build());
            var sut = new StatPrereq(StatBlock.With().Dex(15).Wis(9).Build());

            Check.That(sut.IsSatisfiedBy(character)).IsTrue();
        }

        [Fact]
        public void Can_Check_That_Character_Does_Not_Satisfy()
        {
            var character = new Character(StatBlock.With().Default().Str(13).Dex(15).Wis(10).Build());
            var sut = new StatPrereq(StatBlock.With().Dex(15).Wis(9).Str(15).Build());

            Check.That(sut.IsSatisfiedBy(character)).IsFalse();
        }
    }
}