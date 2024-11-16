using DeckScaler.Component;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class UnitPortraitView : BaseListener<Model, UnitID>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private static SpriteSheet SpriteSheet => Services.Get<Configs>().SpriteSheet;

        public override void OnValueChanged(Entity<Model> entity, UnitID component)
            => _spriteRenderer.sprite = SpriteSheet.UnitPortraits[component.Value];
    }
}