using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DeckScaler.Cheats.Component;
using DeckScaler.Service;

namespace DeckScaler.Cheats.Systems
{
    public class ParseSpawnTeammateCheat : ParseCheatBaseSystem
    {
        private static UnitsConfig Config => Services.Get<IConfigs>().Units;
        private static IDebug      Debug  => Services.Get<IDebug>();

        protected override string Pattern => "spawn teammate (.+)";

        protected override bool TryParse(IList<Group> groups)
        {
            var unitID = $"{Constants.TableID.Allies}{groups[1]}";

            var unitConfig = Config.Allies.FirstOrDefault((c) => c.ID == unitID);
            if (unitConfig is null)
            {
                Debug.LogError(nameof(Cheats), $"Has no teammate with ID {unitID}!");
                return false;
            }

            CreateEntity.Cheat().Add<SpawnTeammate, UnitIDRef>(unitConfig.ID);

            return true;
        }
    }
}