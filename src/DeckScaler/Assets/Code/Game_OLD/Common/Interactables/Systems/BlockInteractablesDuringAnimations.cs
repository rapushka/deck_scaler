using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class BlockInteractablesDuringAnimations : IExecuteSystem
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
                    .And<WaitingForAnimations>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _turnTrackers)
            foreach (var interactable in _interactables)
            {
                interactable.Is<Interactable>(false);
            }
        }
    }
}