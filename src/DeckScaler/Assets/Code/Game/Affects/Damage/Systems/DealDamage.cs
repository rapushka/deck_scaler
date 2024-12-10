using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class DealDamage : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _attacks = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<DealDamageAffect>()
                .And<AffectValue>()
                .And<TargetID>()
                .Build()
        );

        public void Execute()
        {
            foreach (var attack in _attacks)
            {
                var target = attack.Get<TargetID>().Value.GetEntity();
                var damage = attack.Get<AffectValue>().Value;

                target.Increment<Health>(-damage);
            }
        }
    }
}