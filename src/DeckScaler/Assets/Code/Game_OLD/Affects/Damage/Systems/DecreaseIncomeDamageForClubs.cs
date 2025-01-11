using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DecreaseIncomeDamageForClubs : IExecuteSystem
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
                var target = attack.Get<TargetID, EntityID>().GetEntity();
                if (!target.InSuit<Component.Suit>(Suit.Clubs))
                    continue;

                var power = target.Get<Power, int>();
                attack.Increment<AffectValue>(-power, min: 0);
            }
        }
    }
}