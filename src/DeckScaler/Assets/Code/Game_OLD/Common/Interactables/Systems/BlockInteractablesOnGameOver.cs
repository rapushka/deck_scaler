using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class BlockInteractablesOnGameOver : IExecuteSystem
    {
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
            foreach (var _ in _gameOverTimers)
            foreach (var interactable in _interactables)
            {
                interactable.Is<Interactable>(false);
            }
        }
    }
}