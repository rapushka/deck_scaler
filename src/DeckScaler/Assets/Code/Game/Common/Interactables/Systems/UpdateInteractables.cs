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
        private readonly IGroup<Entity<Game>> _gameOverTimers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<GameOverAfter>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var turnTracker in _turnTrackers)
            foreach (var interactable in _interactables)
            {
                var isWaiting = turnTracker.Is<WaitingForAnimations>();
                var isPlayerTurn = turnTracker.IsPlayerTurn();
                var isGameOver = _gameOverTimers.Any();

                var playerCanInteract = !isWaiting && isPlayerTurn && !isGameOver;
                interactable.Is<Interactable>(playerCanInteract);
            }
        }
    }
}