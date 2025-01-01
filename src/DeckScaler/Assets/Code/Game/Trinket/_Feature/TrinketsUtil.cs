using System.Collections.Generic;
using DeckScaler.Service;

namespace DeckScaler
{
    public class TrinketsUtil
    {
        private static IRandom Random => ServiceLocator.Resolve<IRandom>();

        private static AllTrinketsConfig Config => ServiceLocator.Resolve<IConfigs>().Trinkets;

        public IEnumerable<TrinketIDRef> GetRandomTrinketID(int count)
        {
            for (var i = 0; i < count; i++)
                yield return Random.PickRandom(Config.TrinketIDs);
        }
    }
}