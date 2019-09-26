using System.Collections.Generic;

namespace PFFeatTree
{
    public class StatBlock
    {
        //TODO: Evaluate logic of storing in dict vs naked
        private readonly Dictionary<Stat, int> _constraints;
        public IReadOnlyDictionary<Stat, int> Constraints => _constraints;

        public StatBlock(Dictionary<Stat, int> constraints)
        {
            _constraints = constraints;
        }

        public class Builder
        {
            private readonly Dictionary<Stat, int> _constraints = new Dictionary<Stat, int>();

            public Builder Str(int value)
            {
                _constraints[Stat.Str] = value;
                return this;
            }

            public Builder Dex(int value)
            {
                _constraints[Stat.Dex] = value;
                return this;
            }

            public Builder Con(int value)
            {
                _constraints[Stat.Con] = value;
                return this;
            }

            public Builder Int(int value)
            {
                _constraints[Stat.Int] = value;
                return this;
            }

            public Builder Wis(int value)
            {
                _constraints[Stat.Wis] = value;
                return this;
            }

            public Builder Cha(int value)
            {
                _constraints[Stat.Cha] = value;
                return this;
            }

            public Builder Bab(int value)
            {
                _constraints[Stat.Bab] = value;
                return this;
            }

            public Builder Cl(int value)
            {
                _constraints[Stat.Cl] = value;
                return this;
            }

            public StatBlock Build()
            {
                return new StatBlock(_constraints);
            }
        }

        public static Builder With()
        {
            return new Builder();
        }

        public int this[Stat key] => Constraints.GetValueOrDefault(key, -1);

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