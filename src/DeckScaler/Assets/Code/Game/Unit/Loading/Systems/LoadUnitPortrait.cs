using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static DeckScaler.MatcherBuilder<DeckScaler.Game>;

namespace DeckScaler.Systems
{
    public class LoadUnitPortrait : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                With<Loading>()
                    .And<UnitID>()
                    .And<Portrait>()
            );

        private static SpriteSheet SpriteSheet => Services.Get<Configs>().SpriteSheet;

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var portrait = entity.Get<Portrait, SpriteRenderer>();
                portrait.sprite = SpriteSheet.UnitPortraits[entity.Get<UnitID>().Value];
            }
        }
    }
}