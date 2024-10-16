using DeckScaler.Systems;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class MainFeature : Feature
    {
        public MainFeature()
            : base(nameof(MainFeature))
        {
            Add(new TestSpawnLead());
            Add(new SpawnEnemyForEachAlly());

            Add(new SpawnAllyActionCard());
            // Add(new SetupPlayerCardView()); TODO: now it duplicates code from SpawnAllyActionCard. Remove?

            Add(new BoilerplateFeature(Contexts.Instance));
        }
    }
}