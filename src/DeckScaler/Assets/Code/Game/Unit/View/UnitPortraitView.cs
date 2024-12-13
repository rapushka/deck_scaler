using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class UnitPortraitView : BaseListener<Game, Unit>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private static SpriteSheet SpriteSheet => ServiceLocator.Resolve<IConfigs>().SpriteSheet;

        public override void OnValueChanged(Entity<Game> entity, Unit component)
            => _spriteRenderer.sprite = SpriteSheet.UnitPortraits[component.Value];
    }
}