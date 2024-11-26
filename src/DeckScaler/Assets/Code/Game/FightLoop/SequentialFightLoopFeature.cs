using DeckScaler.Component;
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class SequentialFightLoopFeature : Feature
    {
        public SequentialFightLoopFeature()
            : base(nameof(SequentialFightLoopFeature))
        {
            Add(new StartWithPlayerPrepareStep());

            Add(new BlockFightStateChangeIfAny<PrepareAttack>());
            Add(new BlockFightStateChangeIfAny<PlayingAnimation>());

            Add(new ReactOnRequestEndPlayerPrepareStep());

            Add(new ChangeFightStateOnRequest());

            Add(new OnPlayerAttackStartedRequestEnemyAttack());
            Add(new OnEnemyAttackStartedRequestPlayerPrepare());

            Add(new AttackFeature());
        }
    }
}