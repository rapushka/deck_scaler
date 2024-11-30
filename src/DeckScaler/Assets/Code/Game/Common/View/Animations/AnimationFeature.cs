using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class AnimationFeature : Feature
    {
        public AnimationFeature()
            : base(nameof(AnimationFeature))
        {
            Add(new PlayAttackAnimation());
            Add(new PlayFlinchAnimation());

            Add(new UpdateTargetPosition());

            Add(new StopAnimatingMovementAfterTimerElapsed());
            Add(new MarkUnitAppearedAfterAnimatedMovementCompleted());

            Add(new CleanupCompletedAnimations());
            Add(new OnAnimationCompletedRemoveAnimationsFlags());
        }
    }
}