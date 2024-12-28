using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class SpawnRecruitmentCandidates : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RecruitmentStage>()
                    .And<SelectStage>()
            );

        private static IUnitFactory Factory => ServiceLocator.Resolve<IFactories>().Unit;

        private static IRandom Random => ServiceLocator.Resolve<IRandom>();

        private static UnitsConfig Config => ServiceLocator.Resolve<IConfigs>().Units;

        public void Execute()
        {
            foreach (var stage in _stages)
            {
                var recruitCount = stage.Get<RecruitOnStageCount, int>();

                for (var i = 0; i < recruitCount; i++)
                {
                    var randomAllyID = Random.PickRandom(Config.Allies);
                    Factory.CreateRecruitmentCandidate(randomAllyID);
                }
            }
        }
    }
}