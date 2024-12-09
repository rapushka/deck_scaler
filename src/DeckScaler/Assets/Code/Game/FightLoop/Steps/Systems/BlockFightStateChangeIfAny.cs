using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class BlockFightStateChangeIfAny<TComponent> : IExecuteSystem
        where TComponent : IComponent, IInScope<Game>, new()
    {
        private readonly IGroup<Entity<Game>> _entities = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TComponent>()
                .Build()
        );

        public void Execute()
        {
            foreach (var _ in _entities)
            {
                CreateEntity.OneFrame()
                            .Add<DebugName, string>($"blocked by {typeof(TComponent).Name}")
                            .Add<BlockFightStepChange>()
                    ;
            }
        }
    }
}