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
                    .And<RecruitOnStageCount>()
            );

        private static IUnitFactory Factory => ServiceLocator.Resolve<IFactories>().Unit;

        private static UnitsUtil Utils => ServiceLocator.Resolve<IUtils>().Units;

        public void Execute()
        {
            foreach (var stage in _stages)
            {
                var recruitCount = stage.Get<RecruitOnStageCount, int>();

                foreach (var id in Utils.GetRandomAllyIDs(recruitCount))
                {
                    Factory.CreateUnit(id)
                        .Is<RecruitmentCandidate>(true)
                        ;
                }
            }
        }
    }
}