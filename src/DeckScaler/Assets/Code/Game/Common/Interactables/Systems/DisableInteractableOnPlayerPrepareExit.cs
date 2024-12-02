using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class DisableInteractableOnPlayerPrepareExit : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>.With<ExitPlayerPrepareStep>().Build()
            );

        private readonly IGroup<Entity<Game>> _colliders
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<EnableOnlyInPlayerPrepare>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _requests)
            foreach (var entity in _colliders)
            {
                Debug.Log($"disable {entity}");
                entity.Is<Interactable>(false);
            }
        }
    }
}