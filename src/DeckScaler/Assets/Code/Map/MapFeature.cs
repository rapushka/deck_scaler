using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class MapFeature : Feature
    {
        public MapFeature()
            : base(nameof(MapFeature))
        {
            Add(new ShowMapOnStartOfRun());
            Add(new OnLevelSelectedHideMap());
        }
    }
}