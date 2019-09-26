using NFluent;
using Xunit;

namespace PFFeatTree.Tests
{
    public class CharacterTest
    {
        [Fact]
        public void Has_Default_Stat_Block()
        {
            var sut = new Character();

            Check.That(sut.StatBlock.Str).IsEqualTo(10);
            Check.That(sut.StatBlock.Dex).IsEqualTo(10);
            Check.That(sut.StatBlock.Con).IsEqualTo(10);
            Check.That(sut.StatBlock.Int).IsEqualTo(10);
            Check.That(sut.StatBlock.Wis).IsEqualTo(10);
            Check.That(sut.StatBlock.Cha).IsEqualTo(10);
            Check.That(sut.StatBlock.Bab).IsEqualTo(1);
            Check.That(sut.StatBlock.Cl).IsEqualTo(-1);
        }

        [Fact]
        public void Can_Be_Created_With_Custom_Stats()
        {
            StatBlock stats = StatBlock.With()
                .Str(13).Dex(14).Con(15)
                .Int(16).Wis(17).Cha(18)
                .Bab(3).Cl(5).Build();

            var sut = new Character(stats);

            Check.That(sut.StatBlock.Str).IsEqualTo(13);
            Check.That(sut.StatBlock.Dex).IsEqualTo(14);
            Check.That(sut.StatBlock.Con).IsEqualTo(15);
            Check.That(sut.StatBlock.Int).IsEqualTo(16);
            Check.That(sut.StatBlock.Wis).IsEqualTo(17);
            Check.That(sut.StatBlock.Cha).IsEqualTo(18);
            Check.That(sut.StatBlock.Bab).IsEqualTo(3);
            Check.That(sut.StatBlock.Cl).IsEqualTo(5);
        }
    }
}