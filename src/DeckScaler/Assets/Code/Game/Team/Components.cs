using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class Queued : FlagComponent, IInScope<Game> { }

    public sealed class NeedsNewSlot : FlagComponent, IInScope<Game> { }

    public sealed class TeamSlot : ValueComponent<int>, IInScope<Game> { }

    public sealed class HeldTeammate : ValueComponent<EntityID>, IInScope<Game> { }

    public sealed class HeldEnemy : ValueComponent<EntityID>, IInScope<Game> { }

    public sealed class TeammateTransform : ValueComponent<Transform>, IInScope<Game> { }

    public sealed class EnemyTransform : ValueComponent<Transform>, IInScope<Game> { }
}