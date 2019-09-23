using System;
using NFluent;
using PFFeatTree.Tests.Builders;
using Xunit;

namespace PFFeatTree.Tests
{
    public class FeatTest
    {
        [Fact]
        public void Can_Be_Created_By_Builder()
        {
            Feat.FeatBuilder builder = Feat.Builder()
                .WithName("Feat01").WithTextCategory("Cat01")
                .WithTextPrereq("Prereq01").WithTextBenefit("Benefit01")
                .WithTextSource("Source01");

            Feat sut = builder.Build();

            Check.That(sut.Name).IsEqualTo("Feat01");
            Check.That(sut.TextCategory).IsEqualTo("Cat01");
            Check.That(sut.TextPrereq).IsEqualTo("Prereq01");
            Check.That(sut.TextBenefit).IsEqualTo("Benefit01");
            Check.That(sut.TextSource).IsEqualTo("Source01");
        }

        [Fact]
        public void Cannot_Be_Created_With_Nulls()
        {
            Feat.FeatBuilder builder = Feat.Builder();

            void Sut() => builder.Build();

            Check.ThatCode(Sut).Throws<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null, "Cat01", "Prereq01", "Benefit01", "Source01")]
        [InlineData("Feat01", null, "Prereq01", "Benefit01", "Source01")]
        [InlineData("Feat01", "Cat01", null, "Benefit01", "Source01")]
        [InlineData("Feat01", "Cat01", "Prereq01", null, "Source01")]
        [InlineData("Feat01", "Cat01", "Prereq01", "Benefit01", null)]
        public void Cannot_Be_Created_With_Partial_Nulls(string name, string category, string prereq, string benefit, string source)
        {
            Feat.FeatBuilder builder = Feat.Builder()
                .WithName(name).WithTextCategory(category)
                .WithTextPrereq(prereq).WithTextBenefit(benefit)
                .WithTextSource(source);

            void Sut() => builder.Build();

            Check.ThatCode(Sut).Throws<ArgumentNullException>();
        }

        [Fact]
        public void Can_Be_Created_By_Default_Builder()
        {
            Feat.FeatBuilder builder = DefaultFeatBuilder.Get();

            Feat sut = builder.Build();

            Check.That(sut.Name).IsEqualTo("Feat01");
            Check.That(sut.TextCategory).IsEqualTo("Cat01");
            Check.That(sut.TextPrereq).IsEqualTo("Prereq01");
            Check.That(sut.TextBenefit).IsEqualTo("Benefit01");
            Check.That(sut.TextSource).IsEqualTo("Source01");
        }
    }
}