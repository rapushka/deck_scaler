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
                .Replace<DebugName, string>(config.ID.Value)
                .Add<Trinket, TrinketIDRef>(config.ID)
                .Add<TrinketAbility, AffectData>(config.Affect)
                .Add<Price, int>(config.Price)
                .Add<Draggable>()
                .Is<SingleUseTrinket>(config.IsSingleUse)
                ;
        }

        public void CreateTrinketSlot(int index)
        {
            EntityBehaviourFactory.Create(Config.SlotViewPrefab, Vector2.zero)
                .Replace<DebugName, string>($"slot: {index + 1}")
                .Add<TrinketSlot, int>(index)
                ;
        }
    }
}