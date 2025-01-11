using DeckScaler.Component;

namespace DeckScaler
{
    public sealed class ViewFeature : Feature
    {
        public ViewFeature()
            : base(nameof(ViewFeature))
        {
            Add(new LoadViewFeature());

            Add(new AnimationFeature());

            Add(new SortingOrderFeature());

            Add(new MovementFeature());

            Add(new UpdateViewTransformWorldPosition());

            Add(new CleanupElapsedTimers<StopAnimatingMovementAfter>());
            Add(new DestroyEntityBehavioursSystem());
        }
    }
}