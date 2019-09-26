namespace PFFeatTree
{
    public class Character
    {
        public StatBlock StatBlock { get; }

        public Character()
        {
            StatBlock = StatBlock.With().Default().Build();
        }

        public Character(StatBlock statBlock)
        {
            StatBlock = statBlock;
        }
    }
}