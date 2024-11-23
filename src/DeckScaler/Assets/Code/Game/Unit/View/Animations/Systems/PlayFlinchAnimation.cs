using DeckScaler.Component;
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
                    animator.PlayFlinchAnimation();
            }
        }
    }
}