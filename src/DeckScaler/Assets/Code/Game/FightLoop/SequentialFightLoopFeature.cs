using DeckScaler.Component;
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class SequentialFightLoopFeature : Feature
    {
        public SequentialFightLoopFeature()
            : base(nameof(SequentialFightLoopFeature))
        {
            Add(new InitializeCurrentTurnTracker());
            Add(new StartWithPlayerTurn());

            Add(new EnemyAiFeature());
            Add(new GatherEndTurnRequests());

            Add(new AttackFeature());

            Add(new AddWaitForAnimationsIfAny<TimerBeforeAttack>());
            Add(new AddWaitForAnimationsIfAny<PrepareAttack>());
            Add(new AddWaitForAnimationsIfAny<PlayingAnimation>());

            Add(new PassTurn());
        }
    }
}