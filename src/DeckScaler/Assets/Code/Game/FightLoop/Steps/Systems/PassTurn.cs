using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class PassTurn : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _turnTrackers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TurnTracker>()
                    .And<FinishingTurn>()
                    .Without<WaitingForAnimations>()
                    .Without<TurnStarted>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new();

        public void Execute()
        {
            foreach (var turnTracker in _turnTrackers.GetEntities(_buffer))
            {
                var nextTurn = turnTracker.Get<CurrentTurn, Side>().Flip();
                turnTracker
                    .Replace<CurrentTurn, Side>(nextTurn)
                    .Add<TurnStarted>()
                    .Remove<FinishingTurn>()
                    ;
            }
        }
    }
}