using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class TeamSlot : ValueComponent<int>, IInScope<Model> { }

    public sealed class HeldTeammate : ValueComponent<EntityModelIDBase>, IInScope<Model> { }

    public sealed class HeldEnemy : ValueComponent<EntityModelIDBase>, IInScope<Model> { }
}