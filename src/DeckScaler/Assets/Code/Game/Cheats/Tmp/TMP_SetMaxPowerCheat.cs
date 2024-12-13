using System.Collections.Generic;
using System.Text.RegularExpressions;
using DeckScaler.Cheats.Component;
using DeckScaler.Component;
using Entitas;
using Entitas.Generic;
using Processed = DeckScaler.Cheats.Component.Processed;

namespace DeckScaler.Cheats
{
    // ReSharper disable once InconsistentNaming - it's temporary
    public sealed class TMP_SetMaxPowerCheat : IExecuteSystem
    {
        private const int ComicallyLargeNumber = 9_999;

        private readonly IGroup<Entity<Scopes.Cheats>> _cheats
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Scopes.Cheats>
                    .With<Cheat>()
                    .Without<Processed>()
                    .Build()
            );
        private readonly IGroup<Entity<Scopes.Game>> _teammates
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Scopes.Game>
                    .With<Unit>()
                    .And<Teammate>()
                    .Build()
            );
        private readonly List<Entity<Scopes.Cheats>> _buffer = new(32);

        public void Execute()
        {
            foreach (var entity in _cheats.GetEntities(_buffer))
            {
                var cheat = entity.Get<Cheat>().Value;
                var isMatch = TryMatch(cheat, "over 9k");

                if (!isMatch)
                    continue;

                if (TryParse())
                    entity.Is<Processed>(true);
            }
        }

        private bool TryMatch(string cheat, string pattern)
        {
            var match = Regex.Match(cheat, pattern);
            return match.Success;
        }

        private bool TryParse()
        {
            foreach (var teammate in _teammates)
            {
                teammate
                    .Replace<Power, int>(ComicallyLargeNumber)
                    ;
            }

            return true;
        }
    }
}