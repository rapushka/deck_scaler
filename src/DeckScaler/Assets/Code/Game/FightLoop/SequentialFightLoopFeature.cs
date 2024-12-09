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

            Add(new GatherEndTurnRequests());

            Add(new AddWaitForAnimationsIfAny<TimerBeforeAttack>());
            Add(new AddWaitForAnimationsIfAny<PrepareAttack>());
            Add(new AddWaitForAnimationsIfAny<PlayingAnimation>());

            Add(new AttackFeature());

            Add(new PassTurn());

            Add(new RemoveComponent<WaitForAnimations>());
            Add(new RemoveComponent<TurnStarted>());
        }
    }
}