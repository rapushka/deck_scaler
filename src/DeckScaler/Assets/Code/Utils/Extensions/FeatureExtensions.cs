namespace DeckScaler
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

            // Destroy All Entities

            @this.Cleanup();
            @this.TearDown();
        }
    }
}