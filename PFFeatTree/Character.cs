namespace PFFeatTree
{
    public class Character
    {
        public StatBlock Stats { get; }

        public Character()
        {
            Stats = StatBlock.With()
                .Str(10).Dex(10).Con(10)
                .Int(10).Wis(10).Cha(10)
                .Bab(1).Build();
        }

        public Character(StatBlock stats)
        {
            Stats = stats;
        }
    }
}