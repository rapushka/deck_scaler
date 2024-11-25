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

        public void Execute()
        {
            foreach (var entity in _cheats.GetEntities(_buffer))
            {
                var cheat = entity.Get<Cheat>().Value;

                var match = Regex.Match(cheat, Pattern);
                if (!match.Success)
                    continue;

                if (TryParse(match.Groups))
                    entity.Is<Processed>(true);
            }
        }

        protected abstract bool TryParse(IList<Group> groups);
    }
}