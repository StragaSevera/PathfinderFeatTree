using System.Linq;

namespace PFFeatTree
{
    public class FeatPrereq : IPrereq
    {
        public Feat Feat { get; }
        public string Name => Feat.Name;

        public FeatPrereq(Feat feat)
        {
            Feat = feat;
        }

        public bool IsSatisfiedBy(Character character)
        {
            return character.Feats.Contains(Feat);
        }

        public void OnAddedToFeat(Feat target)
        {
            Feat.AddDependent(target);
        }
    }
}