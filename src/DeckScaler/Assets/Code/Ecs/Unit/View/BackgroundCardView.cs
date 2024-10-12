using DeckScaler.Component;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class BackgroundCardView : BaseListener<Scope, Component.Suit>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void OnValueChanged(Entity<Scope> entity, Component.Suit component)
        {
            Sprite sprite = Services.Get<Configs>().Units.CardBackgrounds[component.Value];
        }
    }
}