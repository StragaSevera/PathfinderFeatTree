namespace PFFeatTree
{
    public interface IPrereq
    {
        string Name { get; }
        bool IsSatisfiedBy(Character character);
        void OnAddedToFeat(Feat target);
    }
}