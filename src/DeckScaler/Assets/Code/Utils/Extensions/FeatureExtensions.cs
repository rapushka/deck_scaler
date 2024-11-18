namespace DeckScaler.Utils
{
    public static class FeatureExtensions
    {
        public static void Update(this Entitas.Systems @this)
        {
            @this.Execute();
            @this.Cleanup();
        }

        public static void Dispose(this Entitas.Systems @this)
        {
            @this.DeactivateReactiveSystems();
            @this.ClearReactiveSystems();

            // TODO: Destroy All Entities

            @this.Cleanup();
            @this.TearDown();
        }
    }
}