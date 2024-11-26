using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class ViewFeature : Feature
    {
        public ViewFeature()
            : base(nameof(ViewFeature))
        {
            Add(new LoadViewFeature());

            Add(new AnimationFeature());

            Add(new UpdateHealthProgressBar());

            Add(new SetParentForViewTransform());
            Add(new SetPositionForViewTransform());
            Add(new SetWorldPositionForViewTransform());

            Add(new UpdateLastWorldPositionFromViewTransform());
            
            Add(new DestroyEntityBehaviours());
        }
    }
}