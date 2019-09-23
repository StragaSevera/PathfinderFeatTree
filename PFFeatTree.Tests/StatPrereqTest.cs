using System.Collections.Generic;
using NFluent;
using Xunit;

namespace PFFeatTree.Tests
{
    public class StatPrereqTest
    {
        [Fact]
        public void Can_Be_Created_With_Dict()
        {
            var sut = new StatPrereq(new Dictionary<Stat, int>
            {
                [Stat.Str] = 13,
                [Stat.Bab] = 2
            });

            Check.That(sut.Constraints).HasSize(2);
            Check.That(sut.Constraints[Stat.Str]).IsEqualTo(13);
            Check.That(sut.Constraints[Stat.Bab]).IsEqualTo(2);
        }

        [Fact]
        public void Can_Be_Created_By_Builder()
        {
            StatPrereq sut = StatPrereq.With().Str(13).Dex(14).Con(15).Int(16).Wis(17).Cha(18).Bab
            (3).Cl(5).Build();

            Check.That(sut.Constraints).HasSize(8);
            Check.That(sut.Constraints[Stat.Str]).IsEqualTo(13);
            Check.That(sut.Constraints[Stat.Dex]).IsEqualTo(14);
            Check.That(sut.Constraints[Stat.Con]).IsEqualTo(15);
            Check.That(sut.Constraints[Stat.Int]).IsEqualTo(16);
            Check.That(sut.Constraints[Stat.Wis]).IsEqualTo(17);
            Check.That(sut.Constraints[Stat.Cha]).IsEqualTo(18);
            Check.That(sut.Constraints[Stat.Bab]).IsEqualTo(3);
            Check.That(sut.Constraints[Stat.Cl]).IsEqualTo(5);
        }
    }
}