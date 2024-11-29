using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TeamScrollFeature : Feature
    {
        public TeamScrollFeature()
            : base(nameof(TeamScrollFeature))
        {
            Add(new SpawnTeamRoot());
            Add(new SpawnTeamRootScroll());
        }
    }
}