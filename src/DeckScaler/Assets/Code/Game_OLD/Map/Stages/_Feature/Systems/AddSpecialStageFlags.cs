using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class AddSpecialStageFlags : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Stage>()
                    .And<Component.StageType>()
                    .And<Initializing>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var stage in _stages)
            {
                stage.Get<Component.StageType, StageType>().Visit(
                    onFight: () => stage.Add<FightStage>(),
                    onRecruitment: () => stage.Add<RecruitmentStage>(),
                    onShop: () => stage.Add<ShopStage>()
                );
            }
        }
    }
}