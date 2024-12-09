using DeckScaler.Component;
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class CleanupsFeature : Feature
    {
        public CleanupsFeature()
            : base(nameof(CleanupsFeature))
        {
            Add(new RemoveComponent<Dropped>());
            Add(new RemoveComponent<ReturnToSlot>());
            Add(new RemoveComponent<ClosestSlotForReorder>());
            Add(new RemoveInputComponent<JustClicked>());

            Add(new RemoveComponent<WaitingForAnimations>());
            Add(new RemoveComponent<TurnStarted>());
            Add(new RemoveComponent<TurnJustEnded>());

            Add(new DestroyGameEntities());
            Add(new DestroyInputEntities());
        }
    }
}