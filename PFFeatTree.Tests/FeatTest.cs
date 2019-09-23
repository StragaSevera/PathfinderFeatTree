using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NFluent;
using PFFeatTree.Tests.Builders;
using Xunit;

namespace PFFeatTree.Tests
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class FeatTest
    {
        public class Building
        {
            [Fact]
            public void Can_Be_Created()
            {
                var sut = new Feat("Feat01", "Cat01", "Prereq01", "Benefit01", "Source01");

                Check.That(sut.Name).IsEqualTo("Feat01");
                Check.That(sut.TextCategory).IsEqualTo("Cat01");
                Check.That(sut.TextPrereq).IsEqualTo("Prereq01");
                Check.That(sut.TextBenefit).IsEqualTo("Benefit01");
                Check.That(sut.TextSource).IsEqualTo("Source01");
            }

            [Theory]
            [InlineData(null, "Cat01", "Prereq01", "Benefit01", "Source01")]
            [InlineData("Feat01", null, "Prereq01", "Benefit01", "Source01")]
            [InlineData("Feat01", "Cat01", null, "Benefit01", "Source01")]
            [InlineData("Feat01", "Cat01", "Prereq01", null, "Source01")]
            [InlineData("Feat01", "Cat01", "Prereq01", "Benefit01", null)]
            public void Cannot_Be_Created_With_Nulls(string name, string category,
                string prereq, string benefit, string source)
            {
                // ReSharper disable once ObjectCreationAsStatement
                void Sut() => new Feat(name, category, prereq, benefit, source);

                Check.ThatCode(Sut).Throws<ArgumentNullException>();
            }

            [Fact]
            public void Can_Be_Created_By_Builder()
            {
                FeatBuilder builder = FeatBuilder.Get();

                Feat sut = builder.Build();

                Check.That(sut.Name).IsEqualTo("Feat01");
                Check.That(sut.TextCategory).IsEqualTo("Cat01");
                Check.That(sut.TextPrereq).IsEqualTo("Prereq01");
                Check.That(sut.TextBenefit).IsEqualTo("Benefit01");
                Check.That(sut.TextSource).IsEqualTo("Source01");
            }

            [Fact]
            public void Can_Be_Created_By_Builder_With_Num()
            {
                FeatBuilder builder = FeatBuilder.Get(2);

                Feat sut = builder.Build();

                Check.That(sut.Name).IsEqualTo("Feat02");
                Check.That(sut.TextCategory).IsEqualTo("Cat02");
                Check.That(sut.TextPrereq).IsEqualTo("Prereq02");
                Check.That(sut.TextBenefit).IsEqualTo("Benefit02");
                Check.That(sut.TextSource).IsEqualTo("Source02");
            }

            [Fact]
            public void Can_Be_Created_By_Builder_Customized()
            {
                FeatBuilder builder = FeatBuilder.Get()
                    .WithName("Feat02").WithTextCategory("Cat02")
                    .WithTextPrereq("Prereq02").WithTextBenefit("Benefit02")
                    .WithTextSource("Source02");

                Feat sut = builder.Build();

                Check.That(sut.Name).IsEqualTo("Feat02");
                Check.That(sut.TextCategory).IsEqualTo("Cat02");
                Check.That(sut.TextPrereq).IsEqualTo("Prereq02");
                Check.That(sut.TextBenefit).IsEqualTo("Benefit02");
                Check.That(sut.TextSource).IsEqualTo("Source02");
            }
        }

        public class TreeBehaviour
        {
            [Fact]
            public void Can_Add_Feat_Prereqs()
            {
                Feat feat = FeatBuilder.Get().Build();
                Feat sut = FeatBuilder.Get(2).Build();

                sut.AddFeatPrereq(feat);

                Check.That(sut.Prereqs).HasSize(1);
                Check.That(sut.PrereqFeats).ContainsExactly(feat);
                Check.That(feat.Dependents).ContainsExactly(sut);
            }

            [Fact]
            public void Can_Add_Stat_Prereqs()
            {
                StatPrereq prereq = StatPrereq.With().Str(15).Bab(6).Build();
                Feat sut = FeatBuilder.Get().Build();

                sut.AddStatPrereq(prereq);

                Check.That(sut.Prereqs).HasSize(1);
                Check.That(sut.PrereqFeats).IsEmpty();
                Check.That(sut.Prereqs.First()).IsInstanceOf<StatPrereq>();
                Check.That(((StatPrereq) sut.Prereqs.First()).Constraints)
                    .HasSize(2).And.ContainsPair(Stat.Str, 15)
                    .And.ContainsPair(Stat.Bab, 6);
            }
        }
    }
}