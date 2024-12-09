using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class CardBackgroundView : BaseListener<Game, Component.Suit>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private static SpriteSheet SpriteSheet => ServiceLocator.Resolve<IConfigs>().SpriteSheet;

        public override void OnValueChanged(Entity<Game> entity, Component.Suit component)
            => _spriteRenderer.sprite = SpriteSheet.CardBackgrounds[component.Value];
    }
}