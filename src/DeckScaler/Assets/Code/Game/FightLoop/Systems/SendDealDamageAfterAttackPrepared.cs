using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
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

        private static IAffectsFactory Factory => ServiceLocator.Resolve<IFactories>().Affects;

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

                Factory.Create(
                    affectData: new(AffectType.DealDamage, damage),
                    senderID: attacker.ID(),
                    targetID: opponentID
                );
            }
        }
    }
}