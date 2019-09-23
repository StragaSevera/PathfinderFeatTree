using System;
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
    }
}