using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class PlayAttackAnimation : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _attackers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Attack>()
                .And<Component.UnitAnimator>()
                .Build()
        );

        public void Execute()
        {
            foreach (var attacker in _attackers)
            {
                var animator = attacker.Get<Component.UnitAnimator>().Value;
                var target = attacker.Get<Attack>().Value.GetEntity();

                var targetWorldPosition = target.Get<LastWorldPosition>().Value;
                animator.PlayAttackAnimation(targetWorldPosition);
            }
        }
    }
}