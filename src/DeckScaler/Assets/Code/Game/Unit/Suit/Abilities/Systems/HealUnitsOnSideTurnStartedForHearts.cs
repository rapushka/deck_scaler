using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class HealUnitsOnSideTurnStartedForHearts : IExecuteSystem
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

        public void Execute()
        {
            foreach (var turnTracker in _turnTrackers)
            {
                var currentSide = turnTracker.Get<CurrentTurn>().Value;

                foreach (var unit in _units.Where(u => IsOnCurrentSide(u) && IsHearts(u)))
                {
                    var power = unit.Get<Power, int>();
                    unit.Increment<Health>(power);
                }

                continue;

                bool IsOnCurrentSide(Entity<Game> unit) => unit.Get<OnSide, Side>() == currentSide;

                bool IsHearts(Entity<Game> unit) => unit.Get<Component.Suit, Suit>() is Suit.Hearts;
            }
        }
    }
}