using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class UpdateInteractables : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _turnTrackers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TurnTracker>()
                    .And<CurrentTurn>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _interactables
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<EnableOnlyOnPlayerTurn>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var turnTracker in _turnTrackers)
            foreach (var interactable in _interactables)
            {
                var isWaiting = turnTracker.Is<WaitForAnimations>();
                var isPlayerTurn = turnTracker.Get<CurrentTurn, Side>() is Side.Player;

                var playerCanInteract = !isWaiting && isPlayerTurn;
                interactable.Is<Interactable>(playerCanInteract);
            }
        }
    }
}