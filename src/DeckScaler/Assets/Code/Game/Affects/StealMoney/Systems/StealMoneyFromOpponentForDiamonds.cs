using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class StealMoneyFromOpponentForDiamonds : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _turnTrackers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TurnTracker>()
                    .And<TurnStarted>()
                    .And<CurrentTurn>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<OnSide>()
                    .And<Component.Suit>()
                    .Build()
            );

        private static IAffectsFactory Factory => ServiceLocator.Resolve<IFactories>().Affects;

        public void Execute()
        {
            foreach (var turnTracker in _turnTrackers)
            {
                var currentSide = turnTracker.Get<CurrentTurn>().Value;

                foreach (var unit in _units.Where(u => IsOnCurrentSide(u) && IsDiamonds(u)))
                {
                    var opponentID = unit.Get<Opponent, EntityID>();
                    var power = unit.Get<Power, int>();

                    Factory.Create(
                        data: new(AffectType.StealMoney, power),
                        senderID: unit.ID(),
                        targetID: opponentID
                    );
                }

                continue;

                bool IsOnCurrentSide(Entity<Game> unit) => unit.Get<OnSide, Side>() == currentSide;

                bool IsDiamonds(Entity<Game> unit) => unit.InSuit(Suit.Diamonds);
            }
        }
    }
}