using System.Collections.Generic;
using System.Linq;
using Dawn;

namespace PFFeatTree
{
    public class Feat
    {
        public string Name { get; }
        public string TextCategory { get; }
        public string TextPrereq { get; }
        public string TextBenefit { get; }
        public string TextSource { get; }

        private readonly List<IPrereq> _prereqs = new List<IPrereq>();
        public IReadOnlyList<IPrereq> Prereqs => _prereqs;

        //TODO: Fix breaking O in SOLID
        public IEnumerable<Feat> PrereqFeats => Prereqs.OfType<FeatPrereq>().Select(p => p.Feat);

        private readonly List<Feat> _dependents = new List<Feat>();
        public IReadOnlyList<Feat> Dependents => _dependents;

        public Feat(string name, string textCategory,
            string textPrereq, string textBenefit,
            string textSource)
        {
            Name = Guard.Argument(name, nameof(name)).NotNull();
            TextCategory = Guard.Argument(textCategory, nameof(textCategory)).NotNull();
            TextPrereq = Guard.Argument(textPrereq, nameof(textPrereq)).NotNull();
            TextBenefit = Guard.Argument(textBenefit, nameof(textBenefit)).NotNull();
            TextSource = Guard.Argument(textSource, nameof(textSource)).NotNull();
        }

        public void AddFeatPrereq(Feat prereq)
        {
            _prereqs.Add(new FeatPrereq(prereq));
            prereq._dependents.Add(this);
        }

        public void AddStatPrereq(StatPrereq prereq)
        {
            _prereqs.Add(prereq);
        }
    }
}