using DeckScaler.Cheats;
using DeckScaler.Component;
using DeckScaler.Systems;
using Entitas.Generic;

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

            Add(new InputFeature());

            Add(new GameplayHudFeature());

            Add(new SpawnPlayerTeamFromProgress());
            Add(new SpawnRandomEnemy());

            Add(new TeamSlotsFeature());

            Add(new SequentialFightLoopFeature());
            Add(new DamageFeature());
            Add(new DeathFeature());

            Add(new DestroyEntitiesAfterDelay());

            Add(new TeamSlotsViewFeature());
            Add(new ViewFeature());
            Add(new InteractableFeature());

            Add(new RemoveComponent<Dropped>());
            Add(new RemoveComponent<ReturnToSlot>());
            Add(new RemoveComponent<ClosestSlotForReorder>());
            Add(new RemoveInputComponent<JustClicked>());

            Add(new DestroyGameEntities());
            // Add(new CleanupEntityIDFeature());
            Add(new DestroyInputEntities());

            Add(new BoilerplateFeature(Contexts.Instance));
        }
    }
}