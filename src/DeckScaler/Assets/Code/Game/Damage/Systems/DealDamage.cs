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
                .With<Component.DealDamage>()
                .And<Target>()
                .Build()
        );

        public void Execute()
        {
            foreach (var attack in _attacks)
            {
                var target = attack.Get<Target>().Value.GetEntity();
                var damage = attack.Get<Component.DealDamage>().Value;

                target.Increment<Health>(-damage);
            }
        }
    }
}