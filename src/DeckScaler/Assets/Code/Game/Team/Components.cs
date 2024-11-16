using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class TeamSlot : ValueComponent<int>, IInScope<Game> { }

    public sealed class HeldTeammate : ValueComponent<EntityID>, IInScope<Game> { }

    public sealed class HeldEnemy : ValueComponent<EntityID>, IInScope<Game> { }
}