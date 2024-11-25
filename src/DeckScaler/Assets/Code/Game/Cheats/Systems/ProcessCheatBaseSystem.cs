using System.Collections.Generic;
using DeckScaler.Cheats.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Cheats.Systems
{
    public abstract class ProcessCheatBaseSystem<TComponent> : IExecuteSystem
        where TComponent : IComponent, IInScope<Scopes.Cheats>, new()
    {
        private readonly IGroup<Entity<Scopes.Cheats>> _cheats
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Scopes.Cheats>
                    .With<TComponent>()
                    .Without<Processed>()
                    .Build()
            );
        private readonly List<Entity<Scopes.Cheats>> _buffer = new(32);

        public void Execute()
        {
            foreach (var entity in _cheats.GetEntities(_buffer))
            {
                if (TryProcess(entity, entity.Get<TComponent>()))
                    entity.Is<Processed>(true);
            }
        }

        protected abstract bool TryProcess(Entity<Scopes.Cheats> entity, TComponent component);
    }
}