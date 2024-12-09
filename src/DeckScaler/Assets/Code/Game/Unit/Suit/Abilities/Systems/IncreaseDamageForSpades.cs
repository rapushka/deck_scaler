using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class IncreaseDamageForSpades : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _attacks = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Component.DealDamage>()
                .And<Sender>()
                .Build()
        );

        public void Execute()
        {
            foreach (var attack in _attacks)
            {
                var attacker = attack.Get<Sender, EntityID>().GetEntity();
                var attackerSuit = attacker.Get<Component.Suit, Suit>();

                if (attackerSuit is not Suit.Spades)
                    continue;

                var attackerPower = attacker.Get<Power, int>();
                attack.Increment<Component.DealDamage>(attackerPower);
            }
        }
    }
}