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
    }
}