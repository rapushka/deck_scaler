using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class SendDealDamageWithAttack : IExecuteSystem
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
                var opponentID = attacker.Get<Attack>().Value;
                var damage = attacker.Get<BaseDamage>().Value;

                CreateEntity.OneFrame()
                            .Add<Component.DealDamage, int>(damage)
                            .Add<Sender, EntityID>(attacker.ID())
                            .Add<Target, EntityID>(opponentID)
                    ;
            }
        }
    }
}