using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class TeamSlot : ValueComponent<int>, IInScope<Model> { }

    public sealed class HeldTeammate : ValueComponent<Entity<Model>>, IInScope<Model> { }

    public sealed class HeldEnemy : ValueComponent<Entity<Model>>, IInScope<Model> { }
}