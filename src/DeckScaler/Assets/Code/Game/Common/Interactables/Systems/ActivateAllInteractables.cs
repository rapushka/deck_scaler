using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class ActivateAllInteractables : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _interactables
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<EnableOnlyOnPlayerTurn>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var interactable in _interactables)
                interactable.Is<Interactable>(true);
        }
    }
}