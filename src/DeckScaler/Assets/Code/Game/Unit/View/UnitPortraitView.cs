using DeckScaler.Component;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;
using SpriteRenderer = UnityEngine.SpriteRenderer;

namespace DeckScaler
{
    public sealed class UnitPortraitView : BaseListener<Game, UnitID> // TODO:REMOVE ME?
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private static SpriteSheet SpriteSheet => Services.Get<Configs>().SpriteSheet;

        public override void OnValueChanged(Entity<Game> entity, UnitID component)
            => _spriteRenderer.sprite = SpriteSheet.UnitPortraits[component.Value];
    }
}