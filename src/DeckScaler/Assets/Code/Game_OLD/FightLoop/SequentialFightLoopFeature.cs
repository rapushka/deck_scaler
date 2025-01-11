using DeckScaler.Component;

namespace DeckScaler
{
    public sealed class SequentialFightLoopFeature : Feature
    {
        public SequentialFightLoopFeature()
            : base(nameof(SequentialFightLoopFeature))
        {
            Add(new CreateTurnTracker());
            Add(new StartFightStageWithPlayerTurn());

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