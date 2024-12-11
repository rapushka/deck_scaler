using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class HealUnitsOnSideTurnStartedForHearts : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<OnSide>()
                    .And<Component.Suit>()
                    .And<TriggerOnTurnStartedAbility>()
                    .Build()
            );

        private static IAffectsFactory Factory => ServiceLocator.Resolve<IFactories>().Affects;

        public void Execute()
        {
            foreach (var unit in _units.Where(unit => unit.InSuit(Suit.Hearts)))
            {
                var power = unit.Get<Power, int>();
                var unitID = unit.ID();

                Factory.Create(
                    data: new(AffectType.Heal, power),
                    senderID: unitID,
                    targetID: unitID
                );
            }
        }
    }
}