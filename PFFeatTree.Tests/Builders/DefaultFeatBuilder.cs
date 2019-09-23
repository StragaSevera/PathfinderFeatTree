namespace PFFeatTree.Tests.Builders
{
    public class FeatBuilder
    {
        private string Name { get; set; }
        private string TextCategory { get; set; }
        private string TextPrereq { get; set; }
        private string TextBenefit { get; set; }
        private string TextSource { get; set; }

        private FeatBuilder() {}

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

        public static FeatBuilder Get(int i = 1)
        {
            string num = i.ToString("D2");
            return new FeatBuilder().WithName($"Feat{num}").WithTextCategory($"Cat{num}")
                .WithTextPrereq($"Prereq{num}").WithTextBenefit($"Benefit{num}")
                .WithTextSource($"Source{num}");
        }
    }
}