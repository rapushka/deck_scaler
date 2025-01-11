using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnTurnStartedNotifyUnits : IExecuteSystem
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
                    .With<Unit>()
                    .And<OnSide>()
                    .And<SlotIndex>()
                    .Build()
            );

        private static UnitViewConfig Config => ServiceLocator.Resolve<IConfigs>().UnitView;

        private static float DelayBetweenUnits => Config.DelayBetweenOnTurnStartAbilities;

        public void Execute()
        {
            foreach (var turnTracker in _turnTrackers)
            {
                var currentSide = turnTracker.Get<CurrentTurn>().Value;

                foreach (var unit in _units.Where(unit => unit.Get<OnSide, Side>() == currentSide))
                {
                    var slotIndex = unit.Get<SlotIndex, int>();
                    unit.Add<SendTurnStartedAfter, Timer>(new(DelayBetweenUnits * slotIndex));
                }
            }
        }
    }
}