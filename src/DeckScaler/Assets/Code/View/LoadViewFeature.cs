namespace DeckScaler.Systems
{
    public sealed class LoadViewFeature : Feature
    {
        public LoadViewFeature()
            : base(nameof(LoadViewFeature))
        {
            Add(new LoadUnitPortrait());
            Add(new LoadCardBackgroundsPortrait());

            Add(new MarkLoaded());
        }
    }
}