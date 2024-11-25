using DeckScaler.Component;
using DeckScaler.Scopes;
using DG.Tweening;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class PlayFlinchAnimation : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _attacks = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Component.DealDamage>()
                .And<Target>()
                .Build()
        );

        public void Execute()
        {
            foreach (var attack in _attacks)
            {
                var target = attack.Get<Target>().Value.GetEntity();

                if (target.TryGet<Component.UnitAnimator, UnitAnimator>(out var animator))
                {
                    var tween = animator.PlayFlinchAnimation();
                    target
                        .Add<PlayingAnimation, Tween>(tween)
                        .Add<Component.AnimationType, AnimationType>(AnimationType.Flinch)
                        ;
                }
            }
        }
    }
}