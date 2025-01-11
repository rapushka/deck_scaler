using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class StealMoneyFromOpponentForDiamonds : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Unit>()
                    .And<OnSide>()
                    .And<Component.Suit>()
                    .And<Opponent>()
                    .And<TriggerOnTurnStartedAbility>()
                    .Build()
            );

        private static IAffectsFactory Factory => ServiceLocator.Resolve<IFactories>().Affects;

        public void Execute()
        {
            foreach (var unit in _units.Where(unit => unit.InSuit(Suit.Diamonds)))
            {
                var opponentID = unit.Get<Opponent, EntityID>();
                var power = unit.Get<Power, int>();

                Factory.Create(
                    data: new(AffectType.StealMoney, power),
                    senderID: unit.ID(),
                    targetID: opponentID
                );
            }
        }
    }
}