namespace DeckScaler
{
    public sealed class TeamSlotsFeature : Feature
    {
        public TeamSlotsFeature()
            : base(nameof(TeamSlotsFeature))
        {
            Add(new AssignUnitToEmptySlot());
        }
    }
}