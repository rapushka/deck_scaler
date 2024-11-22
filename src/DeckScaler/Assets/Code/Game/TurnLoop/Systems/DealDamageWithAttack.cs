using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class DealDamageWithAttack : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _attackers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Attack>()
                .Build()
        );

        public void Execute()
        {
            foreach (var attacker in _attackers)
            {
                var opponent = attacker.Get<Attack>().Value.GetEntity();
                var damage = attacker.Get<BaseDamage>().Value;

                opponent.Replace<Health, int>(opponent.Get<Health>().Value - damage);
            }
        }
    }
}