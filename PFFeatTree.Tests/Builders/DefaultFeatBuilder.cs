namespace PFFeatTree.Tests.Builders
{
    public static class DefaultFeatBuilder
    {
        public static Feat.FeatBuilder Get()
        {
            return Feat.Builder().WithName("Feat01").WithTextCategory("Cat01")
                .WithTextPrereq("Prereq01").WithTextBenefit("Benefit01")
                .WithTextSource("Source01");
        }
    }
}