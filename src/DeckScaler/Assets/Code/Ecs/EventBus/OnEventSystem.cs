using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public abstract class OnEventSystem<TComponent> : IExecuteSystem
        where TComponent : IComponent, IInScope<Game>, new()
    {
        private readonly IGroup<Entity<Game>> _events = Contexts.Instance.GetGroup(ScopeMatcher<Game>.Get<TComponent>());

        public void Execute()
        {
            foreach (var @event in _events)
                OnEvent(@event.Get<TComponent>());
        }

        protected abstract void OnEvent(TComponent @event);
    }
}