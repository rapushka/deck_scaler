using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnUnitHealPlayNumbersView : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _affects
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<HealAffect>()
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
                    var heal = affect.Get<AffectValue, int>();
                    numbersView.Play(heal, FloatingNumberView.Type.Heal);
                }
            }
        }
    }
}