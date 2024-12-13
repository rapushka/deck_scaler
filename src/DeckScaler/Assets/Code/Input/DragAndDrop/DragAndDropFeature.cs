using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class DragAndDropFeature : Feature
    {
        public DragAndDropFeature()
            : base(nameof(DragAndDropFeature))
        {
            Add(new StartDragging());

            Add(new StopAutoPlacingDraggedUnit());
            Add(new MoveDraggedEntitiesWithCursor());

            Add(new DropCurrentDraggingEntity());

            Add(new StopAutoPlacingDraggedUnit());
            Add(new ReturnDroppedEntityToSlot());

            Add(new FindClosestSittingUnitToCursor());
            Add(new SwapDraggedUnitToClosestSlot());
        }
    }
}