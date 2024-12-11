using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class MapFeature : Feature
    {
        public MapFeature()
            : base(nameof(MapFeature))
        {
            Add(new InitializeAndShowMapOnStartOfRun());
            Add(new OnLevelCompletedShowMap());
            Add(new OnLevelSelectedHideMap());

            Add(new HideEntitiesIfMapIsOpened());
        }
    }
}