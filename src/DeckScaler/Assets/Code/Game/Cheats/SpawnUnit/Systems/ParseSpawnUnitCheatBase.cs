using System.Collections.Generic;
using System.Text.RegularExpressions;
using DeckScaler.Cheats.Component;
using DeckScaler.Service;

namespace DeckScaler.Cheats.Systems
{
    public abstract class ParseSpawnUnitCheatBase : ParseCheatBaseSystem
    {
        private static UnitsConfig Config => Services.Get<IConfigs>().Units;
        private static IDebug      Debug  => Services.Get<IDebug>();

        protected abstract string GroupID { get; }
        protected abstract Side   Side    { get; }

        protected override bool TryParse(IList<Group> groups)
        {
            var unitID = $"{GroupID}{groups[1]}";

            if (!Config.TryGet(unitID, out var unitConfig))
            {
                Debug.LogError(nameof(Cheats), $"Has no unit with ID {unitID}!");
                return false;
            }

            CreateEntity.Cheat()
                .Add<SpawnUnit, UnitIDRef>(unitConfig.ID)
                .Add<SpawnUnitAtSide, Side>(Side)
                ;

            return true;
        }
    }
}