using DeckScaler.Component;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class PortraitView : BaseListener<Scope, Portrait>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void OnValueChanged(Entity<Scope> entity, Portrait component)
        {
            _spriteRenderer.sprite = component.Value;
        }
    }
}