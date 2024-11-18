using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class Queued : FlagComponent, IInScope<Game> { }

    public sealed class NeedsNewSlot : FlagComponent, IInScope<Game> { }

    public sealed class TeamSlot : ValueComponent<int>, IInScope<Game> { }

    public sealed class HeldTeammate : ValueComponent<EntityID>, IInScope<Game> { }

    public sealed class HeldEnemy : ValueComponent<EntityID>, IInScope<Game> { }
}