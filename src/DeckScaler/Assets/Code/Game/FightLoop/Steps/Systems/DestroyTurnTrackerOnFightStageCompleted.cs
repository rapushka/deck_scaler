using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class DestroyTurnTrackerOnFightStageCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StageCompletedEvent>()
                    .Without<Processed>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _turnTrackers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TurnTracker>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var turnTracker in _turnTrackers)
            {
                turnTracker.Add<Destroy>();
            }
        }
    }
}