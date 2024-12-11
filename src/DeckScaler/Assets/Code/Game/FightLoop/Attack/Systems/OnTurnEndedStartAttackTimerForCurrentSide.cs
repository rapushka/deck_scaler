using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnTurnEndedStartAttackTimerForCurrentSide : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _turnTrackers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TurnTracker>()
                .And<CurrentTurn>()
                .And<TurnJustEnded>()
                .Build()
        );
        private readonly IGroup<Entity<Game>> _units = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<UnitID>()
                .And<OnSide>()
                .Build()
        );

        private static float DelayBetweenAttacks => ServiceLocator.Resolve<IConfigs>().UnitView.DelayBetweenAttacks;

        public void Execute()
        {
            foreach (var turn in _turnTrackers)
            {
                var currentSide = turn.Get<CurrentTurn, Side>();
                foreach (var unit in _units.Where(u => u.Get<OnSide, Side>() == currentSide))
                {
                    var index = unit.Get<SlotIndex, int>();
                    unit.Add<TimerBeforeAttack, Timer>(new(index * DelayBetweenAttacks));
                }
            }
        }
    }
}