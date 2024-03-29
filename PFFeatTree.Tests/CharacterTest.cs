using NFluent;
using PFFeatTree.Tests.Builders;
using Xunit;

namespace PFFeatTree.Tests
{
    public class CharacterTest
    {
        [Fact]
        public void Has_Default_Stat_Block()
        {
            var sut = new Character();

            Check.That(sut.Stats.Str).IsEqualTo(10);
            Check.That(sut.Stats.Dex).IsEqualTo(10);
            Check.That(sut.Stats.Con).IsEqualTo(10);
            Check.That(sut.Stats.Int).IsEqualTo(10);
            Check.That(sut.Stats.Wis).IsEqualTo(10);
            Check.That(sut.Stats.Cha).IsEqualTo(10);
            Check.That(sut.Stats.Bab).IsEqualTo(1);
            Check.That(sut.Stats.Cl).IsEqualTo(-1);

            Check.That(sut.Feats).HasSize(0);
        }

        [Fact]
        public void Can_Be_Created_With_Custom_Stats()
        {
            StatBlock stats = StatBlock.With()
                .Str(13).Dex(14).Con(15)
                .Int(16).Wis(17).Cha(18)
                .Bab(3).Cl(5).Build();

            var sut = new Character(stats);

            Check.That(sut.Stats.Str).IsEqualTo(13);
            Check.That(sut.Stats.Dex).IsEqualTo(14);
            Check.That(sut.Stats.Con).IsEqualTo(15);
            Check.That(sut.Stats.Int).IsEqualTo(16);
            Check.That(sut.Stats.Wis).IsEqualTo(17);
            Check.That(sut.Stats.Cha).IsEqualTo(18);
            Check.That(sut.Stats.Bab).IsEqualTo(3);
            Check.That(sut.Stats.Cl).IsEqualTo(5);

            Check.That(sut.Feats).HasSize(0);
        }

        [Fact]
        public void Can_Be_Created_With_Feats()
        {
            Feat feat = FeatBuilder.Get().Build();
            Feat feat2 = FeatBuilder.Get(2).Build();

            var sut = new Character(new [] {feat, feat2});

            Check.That(sut.Feats).HasSize(2);
            Check.That(sut.Feats).Contains(feat, feat2).InThatOrder();

            Check.That(sut.Stats.Str).IsEqualTo(10);
            Check.That(sut.Stats.Dex).IsEqualTo(10);
            Check.That(sut.Stats.Con).IsEqualTo(10);
            Check.That(sut.Stats.Int).IsEqualTo(10);
            Check.That(sut.Stats.Wis).IsEqualTo(10);
            Check.That(sut.Stats.Cha).IsEqualTo(10);
            Check.That(sut.Stats.Bab).IsEqualTo(1);
            Check.That(sut.Stats.Cl).IsEqualTo(-1);
        }

        [Fact]
        public void Can_Be_Created_With_Feats_And_Stats()
        {
            StatBlock stats = StatBlock.With()
                .Str(13).Dex(14).Con(15)
                .Int(16).Wis(17).Cha(18)
                .Bab(3).Cl(5).Build();
            Feat feat = FeatBuilder.Get().Build();
            Feat feat2 = FeatBuilder.Get(2).Build();

            var sut = new Character(stats, new [] {feat, feat2});

            Check.That(sut.Feats).HasSize(2);
            Check.That(sut.Feats).Contains(feat, feat2).InThatOrder();

            Check.That(sut.Stats.Str).IsEqualTo(13);
            Check.That(sut.Stats.Dex).IsEqualTo(14);
            Check.That(sut.Stats.Con).IsEqualTo(15);
            Check.That(sut.Stats.Int).IsEqualTo(16);
            Check.That(sut.Stats.Wis).IsEqualTo(17);
            Check.That(sut.Stats.Cha).IsEqualTo(18);
            Check.That(sut.Stats.Bab).IsEqualTo(3);
            Check.That(sut.Stats.Cl).IsEqualTo(5);
        }
    }
}