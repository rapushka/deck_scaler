using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class DecreaseIncomeDamageForClubs : IExecuteSystem
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
                var target = attack.Get<Target, EntityID>().GetEntity();
                if (!target.InSuit<Component.Suit>(Suit.Clubs))
                    continue;

                var power = target.Get<Power, int>();
                attack.Increment<Component.DealDamage>(-power, min: 0);
            }
        }
    }
}