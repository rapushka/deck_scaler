using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class MapFeature : Feature
    {
        public MapFeature()
            : base(nameof(MapFeature))
        {
            Add(new InitializeAndShowMapOnStartOfRun());

            Add(new MarkLevelCompleted());
            Add(new MarkStreetAsCompleted());
            Add(new OpenMapOnLevelCompleted());
            Add(new OpenMapAfterDelay());
            Add(new OnLevelSelectedHideMap());

            Add(new MarkLevelCompletedEventProcessed());

            Add(new HideEntitiesIfMapIsOpened());
        }
    }
}