using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class RestockShopOnShotStageSelected : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShopStage>()
                    .And<SelectStage>()
            );

        public void Execute()
        {
            foreach (var stage in _stages)
                stage.Add<RestockShop>();
        }
    }
}