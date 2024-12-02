using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class SendDealDamageAfterAttackPrepared : IExecuteSystem
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
                var damage = attacker.Get<Damage>().Value;

                if (opponentID.IsEntityDead())
                    continue;

                CreateEntity.OneFrame()
                            .Add<Component.DealDamage, int>(damage)
                            .Add<Sender, EntityID>(attacker.ID())
                            .Add<Target, EntityID>(opponentID)
                    ;
            }
        }
    }
}