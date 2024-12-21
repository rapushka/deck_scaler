using System.Collections.Generic;
using System.Text.RegularExpressions;
using DeckScaler.Cheats.Component;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using Processed = DeckScaler.Cheats.Component.Processed;

namespace DeckScaler.Cheats
{
    // ReSharper disable once InconsistentNaming - it's temporary
    public sealed class TMP_SkipStageCheat : IExecuteSystem
    {
        private readonly IGroup<Entity<Scopes.Cheats>> _cheats
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Scopes.Cheats>
                    .With<Cheat>()
                    .Without<Processed>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _aliveEnemies
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Enemy>()
                    .Without<Dead>()
                    .Build()
            );
        private readonly List<Entity<Scopes.Cheats>> _cheatsBuffer = new(32);

        private static StagesUtil Utils => ServiceLocator.Resolve<IUtils>().Stages;

        private static IDebug Debug => ServiceLocator.Resolve<IDebug>();

        /// Returns null if on Map View
        private static Entity<Game> CurrentStage
            => Contexts.Instance.Get<Game>().Unique.GetEntityOrDefault<CurrentStage>();

        public void Execute()
        {
            foreach (var entity in _cheats.GetEntities(_cheatsBuffer))
            {
                var cheat = entity.Get<Cheat>().Value;
                var isMatch = TryMatch(cheat, "skip");

                if (!isMatch)
                    continue;

                if (TryProcess())
                    entity.Is<Processed>(true);
            }
        }

        private bool TryMatch(string cheat, string pattern)
        {
            var match = Regex.Match(cheat, pattern);
            return match.Success;
        }

        private bool TryProcess()
        {
            if (CurrentStage is null)
            {
                Debug.LogError(nameof(Cheats), "Trying to skip level on Map View");
                return false;
            }

            if (CurrentStage.Is<FightStage>())
                KillAllEnemies();
            else
                Utils.CompleteCurrentStage();

            return true;
        }

        private void KillAllEnemies()
        {
            foreach (var enemy in _aliveEnemies)
            {
                enemy
                    .Replace<Health, int>(0)
                    ;
            }
        }
    }
}