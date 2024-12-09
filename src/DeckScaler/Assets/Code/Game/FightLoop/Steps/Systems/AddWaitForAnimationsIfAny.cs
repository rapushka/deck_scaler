using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class AddWaitForAnimationsIfAny<TComponent> : IExecuteSystem
        where TComponent : IComponent, IInScope<Game>, new()
    {
        private readonly IGroup<Entity<Game>> _turnTrackers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TurnTracker>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TComponent>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var turnTracker in _turnTrackers)
            foreach (var _ in _entities)
            {
                turnTracker
                    .Is<WaitForAnimations>(true)
                    ;
            }
        }
    }
}