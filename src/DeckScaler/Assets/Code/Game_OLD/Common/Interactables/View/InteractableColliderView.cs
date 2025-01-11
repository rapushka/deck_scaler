using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class InteractableColliderView : BaseFlagListener<Game, Interactable>
    {
        [SerializeField] private Collider2D _collider;

        protected override void OnValueChanged(Entity<Game> entity)
            => _collider.enabled = entity.Is<Interactable>();
    }
}