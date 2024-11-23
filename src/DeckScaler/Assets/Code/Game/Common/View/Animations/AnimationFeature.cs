using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class AnimationFeature : Feature
    {
        public AnimationFeature()
            : base(nameof(AnimationFeature))
        {
            Add(new UpdateTargetPosition());
        }
    }
}