using DeckScaler.Component;
using DeckScaler.Service;
using UnityEngine;

namespace DeckScaler
{
    public interface ITrinketFactory
    {
        void CreateInPlayerInventory(TrinketIDRef trinketID);

        void CreateTrinketSlot(int index);
    }

    public class TrinketFactory : ITrinketFactory
    {
        private IEntityBehaviourFactory EntityBehaviourFactory => ServiceLocator.Resolve<IFactories>().EntityBehaviour;

        private static AllTrinketsConfig Config => ServiceLocator.Resolve<IConfigs>().Trinkets;

        public void CreateInPlayerInventory(TrinketIDRef trinketID)
        {
            var config = Config.GetConfig(trinketID);

            EntityBehaviourFactory.Create(Config.ViewPrefab, Vector2.zero)
                .Replace<DebugName, string>(ShortID(config.ID.Value))
                .Add<TrinketID, TrinketIDRef>(config.ID)
                .Add<TrinketAbility, AffectData>(config.Affect)
                .Add<Price, int>(config.Price)
                ;
        }

        public void CreateTrinketSlot(int index)
        {
            EntityBehaviourFactory.Create(Config.SlotViewPrefab, Vector2.zero)
                .Replace<DebugName, string>($"slot: {index + 1}")
                .Add<TrinketSlot, int>(index)
                ;
        }

        private string ShortID(string source)
        {
#if UNITY_EDITOR
            return source
                    .Remove(Constants.TableID.Trinkets)
                ;
#else
            return source;
#endif
        }
    }
}