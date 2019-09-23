using System.Collections.Generic;

namespace PFFeatTree
{
    public class StatPrereq : IPrereq
    {
        private StatBlock StatBlock { get; }
        public string Name => StatBlock.ToString();
        public IReadOnlyDictionary<Stat, int> Constraints => StatBlock.Constraints;

        public StatPrereq(StatBlock statBlock)
        {
            StatBlock = statBlock;
        }
    }

}