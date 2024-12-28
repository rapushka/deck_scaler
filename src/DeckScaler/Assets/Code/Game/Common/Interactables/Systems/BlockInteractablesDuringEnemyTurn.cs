using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class BlockInteractablesDuringEnemyTurn : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _interactables
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<EnableOnlyOnPlayerTurn>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _turnTrackers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TurnTracker>()
                    .And<CurrentTurn>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var turnTracker in _turnTrackers)
            foreach (var interactable in _interactables)
            {
                if (turnTracker.IsEnemyTurn())
                    interactable.Is<Interactable>(false);
            }
        }
    }
}