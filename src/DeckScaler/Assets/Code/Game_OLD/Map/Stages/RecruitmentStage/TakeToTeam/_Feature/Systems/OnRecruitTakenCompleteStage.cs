using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnRecruitTakenCompleteStage : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RecruitSelectedEvent>()
                    .Build()
            );

        private static StagesUtil Utils => ServiceLocator.Resolve<IUtils>().Stages;

        public void Execute()
        {
            foreach (var e in _events)
            {
                Utils.CompleteCurrentStage();

                e.Add<Destroy>();
            }
        }
    }
}