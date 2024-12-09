using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnEnemyTurnStartedEndTurn : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _turnTrackers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TurnTracker>()
                    .Without<WaitingForAnimations>()
                    .Without<FinishingTurn>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var turnTracker in _turnTrackers)
            {
                if (turnTracker.IsEnemyTurn())
                    CreateEntity.OneFrame().Add<RequestEndTurn>();
            }
        }
    }
}