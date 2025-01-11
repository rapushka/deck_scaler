using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnUnitDealDamagePlayNumbersView : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _affects
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<DealDamageAffect>()
                    .And<TargetID>()
                    .And<AffectValue>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var affect in _affects)
            {
                var target = affect.GetByID<TargetID>();

                if (target.TryGet<NumbersView, FloatingNumberView>(out var numbersView))
                {
                    var damage = affect.Get<AffectValue, int>();
                    numbersView.Play(damage, FloatingNumberView.Type.Damage);
                }
            }
        }
    }
}