using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class ApplyDealDamageAffect : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _affects
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<DealDamageAffect>()
                    .And<AffectValue>()
                    .And<TargetID>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var affect in _affects)
            {
                var target = affect.Get<TargetID>().Value.GetEntity();
                var damage = affect.Get<AffectValue>().Value;

                target.Increment<Health>(-damage);
            }
        }
    }
}