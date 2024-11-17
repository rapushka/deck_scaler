using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static DeckScaler.MatcherBuilder<DeckScaler.Game>;

namespace DeckScaler.Systems
{
    public class LoadCardBackgroundsPortrait : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                With<Loading>()
                    .And<Component.Suit>()
                    .And<CardBackground>()
            );

        private static SpriteSheet SpriteSheet => Services.Get<Configs>().SpriteSheet;

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var cardBackground = entity.Get<CardBackground, SpriteRenderer>();
                cardBackground.sprite = SpriteSheet.CardBackgrounds[entity.Get<Component.Suit>().Value];
            }
        }
    }
}