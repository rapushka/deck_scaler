using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DeckScaler.Cheats.Component;
using DeckScaler.Service;

namespace DeckScaler.Cheats.Systems
{
    public class ParseSpawnEnemyCheat : ParseCheatBaseSystem
    {
        private static UnitsConfig Config => Services.Get<IConfigs>().Units;
        private static IDebug      Debug  => Services.Get<IDebug>();

        protected override string Pattern => "spawn enemy (.+)";

        protected override bool TryParse(IList<Group> groups)
        {
            var unitID = $"{Constants.TableID.Enemies}{groups[1]}";

            var unitConfig = Config.Enemies.FirstOrDefault((c) => c.ID == unitID);
            if (unitConfig is null)
            {
                Debug.LogError(nameof(Cheats), $"Has no enemy with ID {unitID}!");
                return false;
            }

            CreateEntity.Cheat().Add<SpawnEnemy, UnitIDRef>(unitConfig.ID);

            return true;
        }
    }
}