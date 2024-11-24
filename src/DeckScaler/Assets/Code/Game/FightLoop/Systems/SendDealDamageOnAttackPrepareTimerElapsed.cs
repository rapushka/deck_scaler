using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class SendDealDamageOnAttackPrepareTimerElapsed : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _attackers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<PrepareAttackTimer>()
                .Build()
        );

        public void Execute()
        {
            foreach (var attacker in _attackers)
            {
                if (!attacker.Get<PrepareAttackTimer>().Value.IsElapsed)
                    continue;

                var opponentID = attacker.Get<PrepareAttack>().Value;
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