using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class SortingOrderFeature : Feature
    {
        public SortingOrderFeature()
        {
            Add(new SetIdleUnitSortingLayer());
            Add(new SetDraggingUnitSortingLayer());
            Add(new SetAttackingUnitSortingLayer());

            Add(new UpdateSortingOrderView());
        }
    }
}