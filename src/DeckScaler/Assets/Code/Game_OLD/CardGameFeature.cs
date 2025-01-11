using DeckScaler.Cheats;
using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CardGameFeature : Feature // TODO: Remove me
    {
        public CardGameFeature()
            : base(nameof(CardGameFeature))
        {
#if UNITY_EDITOR
            Add(new CheatsFeature());
#endif

            Add(new InputFeature());

            Add(new GameplayHudFeature());

            Add(new MapFeature());

            Add(new TrinketsFeature());
            Add(new SpawnPlayerTeamFromProgress());
            Add(new OnFightStageSelectedSpawnRandomCountOfRandomEnemies());

            Add(new InventoryFeature());

            Add(new TeamSlotsFeature());

            Add(new SequentialFightLoopFeature());

            Add(new AffectsFeature());
            Add(new DeathFeature());

            Add(new DestroyTurnTrackerOnFightStageCompleted()); // #201

            Add(new DestroyEntitiesAfterDelay());

            Add(new TeamSlotsViewFeature());
            Add(new ViewFeature());
            Add(new ViewInteractablesFeature());

            Add(new CleanupsFeature());

            Add(new BoilerplateFeature(Contexts.Instance));
        }
    }
}