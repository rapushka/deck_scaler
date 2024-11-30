using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class DropCurrentDraggingEntity : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _dragTargets
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Dragging>()
                    .Build()
            );
        private readonly IGroup<Entity<Input>> _releasedCursors
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<Cursor>()
                    .Without<Pressed>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(16);

        public void Execute()
        {
            foreach (var dragTarget in _dragTargets.GetEntities(_buffer))
            foreach (var _ in _releasedCursors)
            {
                dragTarget
                    .Is<Dragging>(false)
                    .Is<Dropped>(true)
                    ;
            }
        }
    }
}