using System.Collections.Generic;
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
                    .Without<WaitForAnimations>()
                    .Without<TurnEnding>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(4);

        public void Execute()
        {
            foreach (var turnTracker in _turnTrackers.GetEntities(_buffer))
            {
                if (turnTracker.IsEnemyTurn())
                    turnTracker.Is<TurnEnding>(true);
            }
        }
    }
}