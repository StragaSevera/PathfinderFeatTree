using System.Collections.Generic;

namespace PFFeatTree
{
    public class StatBlock
    {
        //TODO: Evaluate logic of storing in dict vs naked
        private readonly Dictionary<Stat, int> _stats;
        public IReadOnlyDictionary<Stat, int> Stats => _stats;

        public StatBlock(Dictionary<Stat, int> stats)
        {
            _stats = stats;
        }

        public class Builder
        {
            private readonly Dictionary<Stat, int> _stats = new Dictionary<Stat, int>();

            public Builder Default()
            {
                _stats[Stat.Str] = 10;
                _stats[Stat.Dex] = 10;
                _stats[Stat.Con] = 10;
                _stats[Stat.Int] = 10;
                _stats[Stat.Wis] = 10;
                _stats[Stat.Cha] = 10;
                _stats[Stat.Bab] = 1;
                return this;
            }

            public Builder Str(int value)
            {
                _stats[Stat.Str] = value;
                return this;
            }

            public Builder Dex(int value)
            {
                _stats[Stat.Dex] = value;
                return this;
            }

            public Builder Con(int value)
            {
                _stats[Stat.Con] = value;
                return this;
            }

            public Builder Int(int value)
            {
                _stats[Stat.Int] = value;
                return this;
            }

            public Builder Wis(int value)
            {
                _stats[Stat.Wis] = value;
                return this;
            }

            public Builder Cha(int value)
            {
                _stats[Stat.Cha] = value;
                return this;
            }

            public Builder Bab(int value)
            {
                _stats[Stat.Bab] = value;
                return this;
            }

            public Builder Cl(int value)
            {
                _stats[Stat.Cl] = value;
                return this;
            }

            public StatBlock Build()
            {
                return new StatBlock(_stats);
            }
        }

        public static Builder With()
        {
            return new Builder();
        }

        public int this[Stat key] => Stats.GetValueOrDefault(key, -1);

        public int Str => this[Stat.Str];
        public int Dex => this[Stat.Dex];
        public int Con => this[Stat.Con];
        public int Int => this[Stat.Int];
        public int Wis => this[Stat.Wis];
        public int Cha => this[Stat.Cha];
        public int Bab => this[Stat.Bab];
        public int Cl => this[Stat.Cl];

        public override string ToString()
        {
            return $"STR: {Str}; DEX: {Dex}; CON: {Con}; " +
                   $"INT: {Int}; WIS: {Wis}; CHA: {Cha}; " +
                   $"BAB: {Bab}; CL: {Cl};";
        }
    }


    public enum Stat
    {
        Str,
        Dex,
        Con,
        Int,
        Wis,
        Cha,
        Bab,
        Cl
    }
}