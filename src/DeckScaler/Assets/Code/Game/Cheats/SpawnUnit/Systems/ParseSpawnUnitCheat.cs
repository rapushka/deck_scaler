using System.Collections.Generic;
using System.Text.RegularExpressions;
using DeckScaler.Cheats.Component;
using DeckScaler.Service;

namespace DeckScaler.Cheats.Systems
{
    public class ParseSpawnUnitCheat : ParseCheatBaseSystem
    {
        private static UnitsConfig Config => Services.Get<IConfigs>().Units;
        private static IDebug      Debug  => Services.Get<IDebug>();

        protected override string Pattern => "spawn unit (.+)";

        protected override bool TryParse(IList<Group> groups)
        {
            var unitID = groups[1].ToString();

            if (!Config.TryGet(unitID, out var unitConfig))
            {
                Debug.LogError(nameof(Cheats), "Invalid unit ID!");
                return false;
            }

            if (unitConfig.Type is UnitType.Ally)
                CreateEntity.Cheat().Add<SpawnTeammate, UnitIDRef>(unitConfig.ID);
            else if (unitConfig.Type is UnitType.Enemy)
                CreateEntity.Cheat().Add<SpawnTeammate, UnitIDRef>(unitConfig.ID);
            else
            {
                Debug.LogError(nameof(Cheats), "Invalid unit ID!");
                return false;
            }

            return true;
        }
    }
}