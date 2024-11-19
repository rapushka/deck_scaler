using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class LoadViewFeature : Feature
    {
        public LoadViewFeature()
            : base(nameof(LoadViewFeature))
        {
            Add(new LoadViewsForEntities());
            Add(new LoadUnitPortrait());
            Add(new LoadCardBackgroundsPortrait());
            Add(new LoadUnitStatViews());

            Add(new MarkLoaded());
        }
    }
}