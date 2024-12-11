using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class MapFeature : Feature
    {
        public MapFeature()
            : base(nameof(MapFeature))
        {
            Add(new InitializeAndShowMapOnStartOfRun());

            Add(new OpenMapOnLevelCompleted());
            Add(new OpenMapAfterDelay());
            Add(new OnLevelSelectedHideMap());

            Add(new HideEntitiesIfMapIsOpened());
        }
    }
}