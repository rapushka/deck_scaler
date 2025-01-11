namespace DeckScaler
{
    public sealed class UnitsFeature : Feature
    {
        public UnitsFeature()
            : base(nameof(UnitsFeature))
        {
            Add(new RequestSpawnPlayerTeamFromProgressSystem());

            Add(new SpawnUnitSystem());
        }
    }
}