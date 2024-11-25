using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class RequestChangeFightStep : ValueComponent<FightStep>, IInScope<Game> { }

    public sealed class BlockFightStepChange : FlagComponent, IInScope<Game> { }

    public sealed class EndPlayerPrepareStep : FlagComponent, IInScope<Game> { }

    // # Concrete transitions
    public sealed class PlayerPrepareStepStarted : FlagComponent, IInScope<Game> { }

    public sealed class PlayerAttackStepStarted : FlagComponent, IInScope<Game> { }

    public sealed class EnemyAttackStepStarted : FlagComponent, IInScope<Game> { }
}