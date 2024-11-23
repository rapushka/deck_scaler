using Entitas.Generic;

namespace DeckScaler
{
    public sealed class PrepareAttackAnimationDuration : ValueComponent<float>, IInScope<Game> { }

    public sealed class PrepareAttackTimer : ValueComponent<Timer>, IInScope<Game> { }
}