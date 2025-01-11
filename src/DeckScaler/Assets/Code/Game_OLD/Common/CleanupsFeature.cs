using DeckScaler.Component;

namespace DeckScaler
{
    public sealed class CleanupsFeature : Feature
    {
        public CleanupsFeature()
            : base(nameof(CleanupsFeature))
        {
            Add(new RemoveComponent<Initialized>());
            Add(new MarkAllInitializingEntitiesAsInitialized());

            Add(new RemoveComponent<Dropped>());
            Add(new RemoveComponent<ReturnToSlot>());
            Add(new RemoveComponent<ClosestSlotForReorder>());
            Add(new RemoveInputComponent<CursorClicked>());

            Add(new RemoveComponent<WaitingForAnimations>());
            Add(new RemoveComponent<TurnStarted>());
            Add(new RemoveComponent<TurnJustEnded>());

            Add(new RemoveComponent<SelectStage>());

            Add(new DestroyGameEntitiesSystem());
            Add(new DestroyInputEntitiesSystem());
        }
    }
}