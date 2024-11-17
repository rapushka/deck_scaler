using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class MainFeature : Feature
    {
        public MainFeature()
            : base(nameof(MainFeature))
        {
            Add(new LoadViewsForEntities());
            Add(new LoadUnitPortrait());
            Add(new LoadCardBackgroundsPortrait());
            Add(new MarkLoaded());
        }
    }
}