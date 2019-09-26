using NFluent;
using PFFeatTree.Tests.Builders;
using Xunit;

namespace PFFeatTree.Tests
{
    public class FeatPrereqTest
    {
        [Fact]
        public void Can_Check_That_Character_Satisfies()
        {
            Feat feat = FeatBuilder.Get().Build();
            var character = new Character(new []{feat});

            var sut = new FeatPrereq(feat);

            Check.That(sut.IsSatisfiedBy(character)).IsTrue();
        }

        [Fact]
        public void Can_Check_That_Character_Does_Not_Satisfy()
        {
            Feat feat = FeatBuilder.Get().Build();
            Feat feat2 = FeatBuilder.Get(2).Build();
            var character = new Character(new []{feat});

            var sut = new FeatPrereq(feat2);

            Check.That(sut.IsSatisfiedBy(character)).IsFalse();
        }

        [Fact]
        public void When_Added_To_Feat_Adds_Feat_To_Dependents()
        {
            Feat target = FeatBuilder.Get().Build();
            Feat feat = FeatBuilder.Get(2).Build();
            var sut = new FeatPrereq(feat);

            sut.OnAddedToFeat(target);

            Check.That(feat.Dependents).ContainsExactly(target);
        }
    }
}