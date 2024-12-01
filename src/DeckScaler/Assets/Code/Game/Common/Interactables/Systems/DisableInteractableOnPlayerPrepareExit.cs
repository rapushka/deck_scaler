using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class DisableInteractableOnPlayerPrepareExit : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>.With<EndPlayerPrepareStep>().Build()
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
            foreach (var _ in _requests)
            foreach (var entity in _colliders)
            {
                entity.Is<Interactable>(false);
            }
        }
    }
}