using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class BackgroundCardView : BaseListener<Model, Component.Suit>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private static SpriteSheet SpriteSheet => Services.Get<Configs>().SpriteSheet;

        public override void OnValueChanged(Entity<Model> entity, Component.Suit component)
        {
            _spriteRenderer.sprite = SpriteSheet.CardBackgrounds[component.Value];
        }
    }
}