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

        private Feat(string name, string textCategory,
            string textPrereq, string textBenefit,
            string textSource)
        {
            Name = Guard.Argument(name, nameof(name)).NotNull();
            TextCategory = Guard.Argument(textCategory, nameof(textCategory)).NotNull();
            TextPrereq = Guard.Argument(textPrereq, nameof(textPrereq)).NotNull();
            TextBenefit = Guard.Argument(textBenefit, nameof(textBenefit)).NotNull();
            TextSource = Guard.Argument(textSource, nameof(textSource)).NotNull();
        }

        public static FeatBuilder Builder()
        {
            return new FeatBuilder();
        }

        public class FeatBuilder
        {
            private string Name { get; set; }
            private string TextCategory { get; set; }
            private string TextPrereq { get; set; }
            private string TextBenefit { get; set; }
            private string TextSource { get; set; }

            public FeatBuilder WithName(string name)
            {
                Name = name;
                return this;
            }

            public FeatBuilder WithTextCategory(string textCategory)
            {
                TextCategory = textCategory;
                return this;
            }

            public FeatBuilder WithTextPrereq(string textPrereq)
            {
                TextPrereq = textPrereq;
                return this;
            }

            public FeatBuilder WithTextBenefit(string textBenefit)
            {
                TextBenefit = textBenefit;
                return this;
            }

            public FeatBuilder WithTextSource(string textSource)
            {
                TextSource = textSource;
                return this;
            }

            public Feat Build()
            {
                return new Feat(Name, TextCategory, TextPrereq, TextBenefit, TextSource);
            }
        }
    }
}