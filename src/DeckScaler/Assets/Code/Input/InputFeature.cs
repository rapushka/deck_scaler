using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class InputFeature : Feature
    {
        public InputFeature()
            : base(nameof(InputFeature))
        {
            Add(new SpawnCursorEntity());
            Add(new UpdateCursorWorldPosition());
            Add(new TrackCursorPressed());
        }
    }
}