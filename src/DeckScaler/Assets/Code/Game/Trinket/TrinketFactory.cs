using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface ITrinketFactory
    {
        Entity<Game> CreateInPlayerInventory(TrinketIDRef trinketID);

        Entity<Game> CreateTrinketSlot(int index);

        Entity<Game> CreateTrinket(TrinketIDRef trinketID);
    }

    public class TrinketFactory : ITrinketFactory
    {
        private IEntityBehaviourFactory EntityBehaviourFactory => ServiceLocator.Resolve<IFactories>().EntityBehaviour;

        private static AllTrinketsConfig Config => ServiceLocator.Resolve<IConfigs>().Trinkets;

        private static TrinketsUtil Utils => ServiceLocator.Resolve<IUtils>().Trinket;

        public Entity<Game> CreateInPlayerInventory(TrinketIDRef trinketID)
            => Utils.Obtain(CreateTrinket(trinketID));

        public Entity<Game> CreateTrinket(TrinketIDRef trinketID)
        {
            var config = Config.GetConfig(trinketID);

            return EntityBehaviourFactory.Create(Config.ViewPrefab, Vector2.zero)
                    .Replace<DebugName, string>(config.ID.Value)
                    .Add<Trinket, TrinketIDRef>(config.ID)
                    .Add<TrinketAbility, AffectData>(config.Affect)
                    .Add<Price, int>(config.Price)
                    .Is<SingleUseTrinket>(config.IsSingleUse)
                ;
        }

        public Entity<Game> CreateTrinketSlot(int index)
            => EntityBehaviourFactory.Create(Config.SlotViewPrefab, Vector2.zero)
                .Replace<DebugName, string>($"slot: {index + 1}")
                .Add<TrinketSlot, int>(index)
                .Bump();
    }
}