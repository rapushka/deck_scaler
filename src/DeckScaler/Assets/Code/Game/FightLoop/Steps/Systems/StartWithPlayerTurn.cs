using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class StartWithPlayerTurn : IInitializeSystem
    {
        private readonly IGroup<Entity<Game>> _turnTrackers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TurnTracker>()
                    .Build()
            );

        public void Initialize()
        {
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