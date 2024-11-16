using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class EventBus : IService
    {
        public void Send<TComponent>()
            where TComponent : FlagComponent, IInScope<Model>, new()
        {
            Contexts.Instance.Get<Model>().CreateEntity()
                    .Add<TComponent>()
                    .Add<Destroy>();
        }

        public void Send<TComponent, TValue>(TValue value)
            where TComponent : ValueComponent<TValue>, IInScope<Model>, new()
        {
            Contexts.Instance.Get<Model>().CreateEntity()
                    .Add<TComponent, TValue>(value)
                    .Add<Destroy>();
        }
    }
}