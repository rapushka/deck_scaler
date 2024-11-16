using Entitas.Generic;

namespace DeckScaler.Component
{
    /// <summary> Value is Unit ID </summary>
    public sealed class SpawnAlly : ValueComponent<string>, IInScope<Model> { }

    public sealed class UnitSpawned : ValueComponent<Entity<Model>>, IInScope<Model> { }
}