using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class EnableInteractableOnPlayerPrepareEnter : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _event
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>.With<PlayerPrepareStepStarted>().Build()
            );

        private readonly IGroup<Entity<Game>> _colliders
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Interactable>()
                    .And<EnableOnlyInPlayerPrepare>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _event)
            foreach (var entity in _colliders)
            {
                entity.Is<Interactable>(true);
            }
        }
    }
}