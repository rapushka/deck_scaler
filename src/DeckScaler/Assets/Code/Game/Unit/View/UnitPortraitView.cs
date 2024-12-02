using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class UnitPortraitView : BaseListener<Game, UnitID>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private static SpriteSheet SpriteSheet => Services.Get<IConfigs>().SpriteSheet;

        public override void OnValueChanged(Entity<Game> entity, UnitID component)
            => _spriteRenderer.sprite = SpriteSheet.UnitPortraits[component.Value];
    }
}