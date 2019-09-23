using System.Collections.Generic;

namespace PFFeatTree
{
    public class StatPrereq : IPrereq
    {
        public string Name => ToString();
        private readonly Dictionary<Stat, int> _constraints;

        public IReadOnlyDictionary<Stat, int> Constraints => _constraints;

        public StatPrereq(Dictionary<Stat, int> constraints)
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

            public StatPrereq Build()
            {
                return new StatPrereq(_constraints);
            }
        }

        public static Builder With()
        {
            return new Builder();
        }
    }

    public enum Stat
    {
        Str, Dex, Con, Int, Wis, Cha, Bab, Cl
    }
}