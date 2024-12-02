namespace DeckScaler.Systems
{
    public sealed class LoadViewFeature : Feature
    {
        public LoadViewFeature()
            : base(nameof(LoadViewFeature))
        {
            Add(new MarkLoaded());
        }
    }
}