using System;
using System.Collections.Generic;
using System.Linq;

namespace PFFeatTree
{
    public class StatPrereq : IPrereq
    {
        private StatBlock StatBlock { get; }
        public string Name => StatBlock.ToString();

        public IReadOnlyDictionary<Stat, int> Constraints => StatBlock.Stats;

        public StatPrereq(StatBlock statBlock)
        {
            StatBlock = statBlock;
        }

        public bool IsSatisfiedBy(Character character)
        {
            return Constraints.All(e => character.Stats[e.Key] >= e.Value);
        }

        public void OnAddedToFeat(Feat target)
        {
        }
    }
}