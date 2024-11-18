using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class ViewFeature : Feature
    {
        public ViewFeature()
            : base(nameof(ViewFeature))
        {
            Add(new LoadViewsForEntities());
            Add(new LoadUnitPortrait());
            Add(new LoadCardBackgroundsPortrait());
            Add(new LoadUnitStatViews());
        }
    }
}