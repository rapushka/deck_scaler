using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class PrepareAttackAnimationDuration : ValueComponent<float>, IInScope<Game> { }

    public sealed class PrepareAttackTimer : ValueComponent<Timer>, IInScope<Game> { }
}