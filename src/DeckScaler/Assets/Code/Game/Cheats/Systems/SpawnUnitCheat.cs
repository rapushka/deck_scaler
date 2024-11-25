using System.Collections.Generic;
using System.Text.RegularExpressions;
using DeckScaler.Cheats.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Cheats.Systems
{
    public class SpawnUnitCheat : IExecuteSystem
    {
        private const string Pattern = "spawn unit (.+)";

        private readonly IGroup<Entity<Scopes.Cheats>> _cheats
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Scopes.Cheats>
                    .With<Cheat>()
                    .Without<ProcessedCheat>()
                    .Build()
            );
        private readonly List<Entity<Scopes.Cheats>> _buffer = new(32);

        private static IFactories  Factory => Services.Get<IFactories>();
        private static UnitsConfig Config  => Services.Get<IConfigs>().Units;
        private static IDebug      Debug   => Services.Get<IDebug>();

        public void Execute()
        {
            foreach (var entity in _cheats.GetEntities(_buffer))
            {
                var cheat = entity.Get<Cheat>().Value;

                var match = Regex.Match(cheat, Pattern);
                if (!match.Success)
                    continue;

                var unitID = match.Groups[1].ToString();

                if (!TryCreate(unitID))
                    Debug.LogError(nameof(Cheats), "Invalid unit ID!");

                entity.Is<ProcessedCheat>(true);
            }
        }

        private static bool TryCreate(string unitID)
        {
            if (!Config.TryGetUnitType(unitID, out var unitType))
                return false;

            if (unitType is UnitType.Ally)
                Factory.CreateTeammate(unitID);
            else if (unitType is UnitType.Enemy)
                Factory.CreateEnemy(unitID);
            else
                return false;

            return true;
        }
    }
}