using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public abstract class OnEventSystem<TComponent> : IExecuteSystem
        where TComponent : IComponent, IInScope<Model>, new()
    {
        private readonly IGroup<Entity<Model>> _events = Contexts.Instance.GetGroup(ScopeMatcher<Model>.Get<TComponent>());

        public void Execute()
        {
            foreach (var @event in _events)
                OnEvent(@event.Get<TComponent>());
        }

        protected abstract void OnEvent(TComponent @event);
    }
}