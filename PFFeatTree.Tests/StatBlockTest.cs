using System.Collections.Generic;
using NFluent;
using Xunit;

namespace PFFeatTree.Tests
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class StatBlockTest
    {
        public class Building
        {
            [Fact]
            public void Can_Be_Created_With_Dict()
            {
                var sut = new StatBlock(new Dictionary<Stat, int>
                {
                    [Stat.Str] = 13,
                    [Stat.Bab] = 2
                });

                Check.That(sut.Stats).HasSize(2);
                Check.That(sut.Stats[Stat.Str]).IsEqualTo(13);
                Check.That(sut.Stats[Stat.Bab]).IsEqualTo(2);
            }

            [Fact]
            public void Can_Be_Created_By_Builder()
            {
                StatBlock sut = StatBlock.With()
                    .Str(13).Dex(14).Con(15)
                    .Int(16).Wis(17).Cha(18)
                    .Bab(3).Cl(5).Build();

                Check.That(sut.Stats).HasSize(8);
                Check.That(sut.Stats[Stat.Str]).IsEqualTo(13);
                Check.That(sut.Stats[Stat.Dex]).IsEqualTo(14);
                Check.That(sut.Stats[Stat.Con]).IsEqualTo(15);
                Check.That(sut.Stats[Stat.Int]).IsEqualTo(16);
                Check.That(sut.Stats[Stat.Wis]).IsEqualTo(17);
                Check.That(sut.Stats[Stat.Cha]).IsEqualTo(18);
                Check.That(sut.Stats[Stat.Bab]).IsEqualTo(3);
                Check.That(sut.Stats[Stat.Cl]).IsEqualTo(5);
            }

            [Fact]
            public void Can_Be_Created_By_Builder_With_Defaults()
            {
                StatBlock sut = StatBlock.With().Default()
                    .Str(13).Build();

                Check.That(sut.Stats).HasSize(7);
                Check.That(sut.Stats[Stat.Str]).IsEqualTo(13);
                Check.That(sut.Stats[Stat.Dex]).IsEqualTo(10);
                Check.That(sut.Stats[Stat.Con]).IsEqualTo(10);
                Check.That(sut.Stats[Stat.Int]).IsEqualTo(10);
                Check.That(sut.Stats[Stat.Wis]).IsEqualTo(10);
                Check.That(sut.Stats[Stat.Cha]).IsEqualTo(10);
                Check.That(sut.Stats[Stat.Bab]).IsEqualTo(1);
                Check.That(sut.Stats).Not.ContainsKey(Stat.Cl);
            }
        }

        public class Access
        {
            [Fact]
            public void Can_Be_Accessed_With_Indexer()
            {
                StatBlock sut = StatBlock.With()
                    .Str(13).Dex(14).Con(15)
                    .Int(16).Wis(17).Cha(18)
                    .Bab(3).Cl(5).Build();

                Check.That(sut[Stat.Str]).IsEqualTo(13);
                Check.That(sut[Stat.Dex]).IsEqualTo(14);
                Check.That(sut[Stat.Con]).IsEqualTo(15);
                Check.That(sut[Stat.Int]).IsEqualTo(16);
                Check.That(sut[Stat.Wis]).IsEqualTo(17);
                Check.That(sut[Stat.Cha]).IsEqualTo(18);
                Check.That(sut[Stat.Bab]).IsEqualTo(3);
                Check.That(sut[Stat.Cl]).IsEqualTo(5);
            }

            [Fact]
            public void Indexer_Returns_Negative_When_No_Stat()
            {
                StatBlock sut = StatBlock.With()
                    .Str(13).Build();

                Check.That(sut[Stat.Dex]).IsEqualTo(-1);
            }

            [Fact]
            public void Can_Be_Accessed_With_Utility_Properties()
            {
                StatBlock sut = StatBlock.With()
                    .Str(13).Dex(14).Con(15)
                    .Int(16).Wis(17).Cha(18)
                    .Bab(3).Cl(5).Build();

                Check.That(sut.Str).IsEqualTo(13);
                Check.That(sut.Dex).IsEqualTo(14);
                Check.That(sut.Con).IsEqualTo(15);
                Check.That(sut.Int).IsEqualTo(16);
                Check.That(sut.Wis).IsEqualTo(17);
                Check.That(sut.Cha).IsEqualTo(18);
                Check.That(sut.Bab).IsEqualTo(3);
                Check.That(sut.Cl).IsEqualTo(5);
            }

            [Fact]
            public void Utility_Property_Returns_Negative_When_No_Stat()
            {
                StatBlock sut = StatBlock.With()
                    .Str(13).Build();

                Check.That(sut.Dex).IsEqualTo(-1);
            }
        }

        public class Features
        {
            [Fact]
            public void Can_Be_Converted_To_String()
            {
                StatBlock sut = StatBlock.With()
                    .Str(13).Dex(14).Con(15)
                    .Wis(17).Cha(18)
                    .Bab(3).Cl(5).Build();

                string str = sut.ToString();

                Check.That(str).IsEqualTo("STR: 13; DEX: 14; CON: 15; INT: -1; WIS: 17; CHA: 18; BAB: 3; CL: 5;");
            }
        }
    }
}