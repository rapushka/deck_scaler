using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class StopAutoPlacingDraggedUnit : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _draggedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Dragging>()
                    .And<UnitID>()
                    .And<SittingInSlot>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new();

        public void Execute()
        {
            foreach (var unit in _draggedUnits.GetEntities(_buffer))
            {
                unit
                    .Is<SittingInSlot>(false)
                    .Is<AnimateMovement>(false)
                    ;
            }
        }
    }
}