using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Cursor = DeckScaler.Component.Cursor;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler
{
    public sealed class ScrollTeamRoot : IExecuteSystem
    {
        private readonly IGroup<Entity<Input>> _hoveredEntities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<HoveredEntity>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _teamRoots
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TeamRoot>()
                    .Build()
            );
        private readonly IGroup<Entity<Input>> _cursors
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<Cursor>()
                    .And<Pressed>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var hovered in _hoveredEntities)
            {
                var target = hovered.Get<HoveredEntity, EntityID>().GetEntity();

                if (!target.Is<TeamRootScroll>())
                    continue;

                foreach (var cursor in _cursors)
                foreach (var root in _teamRoots)
                {
                    var delta = cursor.Get<MoveDelta>().Value.With(y: 0);
                    root.Add<Move, Vector2>(delta);
                }
            }
        }
    }
}