using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class GatherEndTurnRequests : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RequestEndTurn>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _turnTrackers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TurnTracker>()
                .Build()
        );

        public void Execute()
        {
            foreach (var _ in _requests)
            foreach (var turnTracker in _turnTrackers)
            {
                turnTracker
                    .Is<TurnJustEnded>(true)
                    .Is<FinishingTurn>(true)
                    .Is<WaitingForAnimations>(true)
                    ;
            }
        }
    }
}