using DeckScaler.Component;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class PortraitView : BaseListener<View, Portrait>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void OnValueChanged(Entity<View> entity, Portrait component)
        {
            _spriteRenderer.sprite = component.Value;
        }
    }
}