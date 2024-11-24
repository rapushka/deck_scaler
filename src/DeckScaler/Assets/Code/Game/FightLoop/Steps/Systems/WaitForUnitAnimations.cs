using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class WaitForUnitAnimations : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _waiters
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<WaitingForAttackAnimations>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _animatedAttackers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<PlayingAnimation>()
                    .And<Component.AnimationType>()
                    .Or<PrepareAttack>()
                    // .Or<PlayingAnimation>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var waiter in _waiters)
            {
                if (_animatedAttackers.Any())
                    return; // yes, return, not continue

                CreateEntity.OneFrame()
                            .Is<AllAnimationsCompleted>(true)
                    ;

                waiter.Add<Destroy>();
            }
        }
    }
}