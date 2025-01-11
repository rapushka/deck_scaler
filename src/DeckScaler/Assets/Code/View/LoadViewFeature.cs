namespace DeckScaler
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