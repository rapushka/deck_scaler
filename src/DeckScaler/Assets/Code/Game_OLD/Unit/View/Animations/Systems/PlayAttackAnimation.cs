using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DG.Tweening;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class PlayAttackAnimation : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _attackers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<PrepareAttack>()
                .And<Component.UnitAnimator>()
                .Without<PlayingAnimation>()
                .Build()
        );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Execute()
        {
            foreach (var attacker in _attackers.GetEntities(_buffer))
            {
                var animator = attacker.Get<Component.UnitAnimator>().Value;
                var target = attacker.Get<PrepareAttack>().Value.GetEntity();

                var targetWorldPosition = target.Get<WorldPosition>().Value;
                var tween = animator.PlayAttackAnimation(targetWorldPosition);

                attacker
                    .Add<PlayingAnimation, Tween>(tween)
                    .Add<PlayingAttackAnimation>()
                    ;
            }
        }
    }
}