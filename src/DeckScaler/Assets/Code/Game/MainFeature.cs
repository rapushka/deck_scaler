using DeckScaler.Cheats;
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class MainFeature : Feature
    {
        public MainFeature()
            : base(nameof(MainFeature))
        {
#if UNITY_EDITOR
            Add(new CheatsFeature());
#endif

            Add(new SpawnPlayerTeamFromProgress());
            Add(new SpawnRandomEnemy());

            Add(new TeamSlotsFeature());
            Add(new TeamSlotsViewFeature());

            Add(new SequentialFightLoopFeature());
            Add(new DamageFeature());

            Add(new ViewFeature());

            Add(new DestroyEntities());
        }
    }
}