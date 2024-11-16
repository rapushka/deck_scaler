using Entitas.Generic;

namespace DeckScaler.Component
{
    public sealed class ID : PrimaryIndexComponent<EntityIDBase>, IInScope<Model>, IInScope<View> { }
}