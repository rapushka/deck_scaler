using System.Collections.Generic;
using System.Text.RegularExpressions;
using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class SpawnUnitCheat : IExecuteSystem
    {
        private const string Pattern = @"spawn unit (.+)";

        private const string AllyGroupID = "Ally";
        private const string EnemyGroupID = "Enemy";

        private readonly IGroup<Entity<Cheats>> _cheats
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Cheats>
                    .With<Cheat>()
                    .Without<Processed>()
                    .Build()
            );
        private readonly List<Entity<Cheats>> _buffer = new(32);

        private static IFactories Factory => Services.Get<IFactories>();

        private static IDebug Debug => Services.Get<IDebug>();

        public void Execute()
        {
            foreach (var entity in _cheats.GetEntities(_buffer))
            {
                var cheat = entity.Get<Cheat>().Value;

                var match = Regex.Match(cheat, Pattern);
                if (!match.Success)
                    continue;

                var unitID = match.Groups[1].ToString();

                if (unitID.Contains(AllyGroupID))
                    Factory.CreateTeammate(unitID);
                else if (unitID.Contains(EnemyGroupID))
                    Factory.CreateEnemy(unitID);
                else
                {
                    Debug.LogError(nameof(Cheats), "Invalid unit ID!");
                    continue;
                }

                entity.Is<Processed>(true);
            }
        }
    }
}