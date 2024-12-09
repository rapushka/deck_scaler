using System.Collections.Generic;
using System.Text.RegularExpressions;
using DeckScaler.Cheats.Component;
using DeckScaler.Service;

namespace DeckScaler.Cheats.Systems
{
    public abstract class ParseSpawnUnitCheatBase : ParseCheatBaseSystem
    {
        private static UnitsConfig Config => ServiceLocator.Get<IConfigs>().Units;
        private static IDebug      Debug  => ServiceLocator.Get<IDebug>();

        protected abstract Side Side { get; }

        protected override bool TryParse(IList<Group> groups)
        {
            var canParse = TryGroup(groups, Constants.TableID.Allies)
                || TryGroup(groups, Constants.TableID.Enemies);

            if (!canParse)
                Debug.LogError(nameof(Cheats), $"No unit with ID {groups[1]}!");

            return canParse;
        }

        private bool TryGroup(IList<Group> groups, string prefix)
        {
            var unitID = $"{prefix}{groups[1]}";

            if (!Config.TryGet(unitID, out var unitConfig))
                return false;

            CreateEntity.Cheat()
                .Add<SpawnUnit, UnitIDRef>(unitConfig.ID)
                .Add<SpawnUnitAtSide, Side>(Side)
                ;

            return true;
        }
    }
}