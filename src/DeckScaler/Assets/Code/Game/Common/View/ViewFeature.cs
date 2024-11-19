using DeckScaler.Component;

namespace DeckScaler
{
    public sealed class ViewFeature : Feature
    {
        public ViewFeature()
            : base(nameof(ViewFeature))
        {
            Add(new LoadViewFeature());

            Add(new TeamSlotsViewFeature());

            Add(new UpdateParent());
            Add(new UpdatePosition());
            Add(new UpdateWorldPosition());
        }
    }
}