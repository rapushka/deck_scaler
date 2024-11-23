using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class ViewFeature : Feature
    {
        public ViewFeature()
            : base(nameof(ViewFeature))
        {
            Add(new LoadViewFeature());

            Add(new PlayAttackAnimation());
            Add(new PlayFlinchAnimation());

            Add(new UpdateHealthProgressBar());

            Add(new UpdateParent());
            Add(new UpdatePosition());
            Add(new UpdateWorldPosition());

            Add(new AnimationFeature());
        }
    }
}