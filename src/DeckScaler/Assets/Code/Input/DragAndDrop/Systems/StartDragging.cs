using DeckScaler.Component;
using Entitas;
using Entitas.Generic;
using Cursor = DeckScaler.Component.Cursor;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler.Systems
{
    public sealed class StartDragging : IExecuteSystem
    {
        private readonly IGroup<Entity<Input>> _hoveredEntities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<HoveredEntity>()
                    .Build()
            );
        private readonly IGroup<Entity<Input>> _cursors
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<Cursor>()
                    .And<JustClicked>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var hovered in _hoveredEntities)
            foreach (var _ in _cursors)
            {
                var target = hovered.Get<HoveredEntity, EntityID>().GetEntity();

                if (target.Is<Draggable>())
                    target.Is<Dragging>(true);
            }
        }
    }
}