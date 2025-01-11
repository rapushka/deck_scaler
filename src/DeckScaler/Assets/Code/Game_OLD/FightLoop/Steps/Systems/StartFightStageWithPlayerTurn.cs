using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class StartFightStageWithPlayerTurn : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _selectedStage
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<SelectStage>()
                    .And<FightStage>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _turnTrackers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TurnTracker>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _selectedStage)
            foreach (var turnTracker in _turnTrackers)
            {
                turnTracker
                    .Add<TurnStarted>()
                    .Add<CurrentTurn, Side>(Side.Player)
                    ;
            }
        }
    }
}