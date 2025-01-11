using System.Collections.Generic;
using System.Text.RegularExpressions;
using DeckScaler.Cheats.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Cheats.Systems
{
    public abstract class ParseCheatBaseSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<Scopes.Cheats>> _cheats
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Scopes.Cheats>
                    .With<Cheat>()
                    .Without<Processed>()
                    .Build()
            );
        private readonly List<Entity<Scopes.Cheats>> _buffer = new(32);

        protected abstract string Pattern { get; }

        protected virtual string Alias => null;

        public void Execute()
        {
            foreach (var entity in _cheats.GetEntities(_buffer))
            {
                var cheat = entity.Get<Cheat>().Value;

                var isMatch = TryMatch(cheat, Pattern, out var match) || TryMatchAlias(cheat, ref match);

                if (!isMatch)
                    continue;

                if (TryParse(match.Groups))
                    entity.Is<Processed>(true);
            }
        }

        private bool TryMatchAlias(string cheat, ref Match match)
        {
            return !Alias.IsEmpty() && TryMatch(cheat, Alias, out match);
        }

        private bool TryMatch(string cheat, string pattern, out Match match)
        {
            match = Regex.Match(cheat, pattern);
            return match.Success;
        }

        protected abstract bool TryParse(IList<Group> groups);
    }
}