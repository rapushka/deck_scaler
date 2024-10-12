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

            Add(new BoilerplateFeature(Contexts.Instance));
        }
    }
}