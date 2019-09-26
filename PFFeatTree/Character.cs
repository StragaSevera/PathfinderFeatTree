using System.Collections.Generic;
using System.Collections.Immutable;

namespace PFFeatTree
{
    public class Character
    {
        public StatBlock Stats { get; }
        public IReadOnlyList<Feat> Feats { get; } = ImmutableList<Feat>.Empty;

        public Character()
        {
            Stats = StatBlock.With().Default().Build();
        }

        public Character(StatBlock stats)
        {
            Stats = stats;
        }

        public Character(IEnumerable<Feat> feats): this()
        {
            Feats = feats.ToImmutableList();
        }

        public Character(StatBlock stats, IEnumerable<Feat> feats): this(stats)
        {
            Feats = feats.ToImmutableList();
        }
    }
}