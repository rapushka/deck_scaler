using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class BoilerplateFeature : Feature
    {
        public BoilerplateFeature(Contexts contexts)
            : base(nameof(BoilerplateFeature))
        {
            Add(new SelfEventSystem<Model, Parent>(contexts));
            Add(new SelfEventSystem<Model, Stats>(contexts));
            Add(new SelfEventSystem<Model, Opponent>(contexts));
            Add(new SelfEventSystem<Model, Health>(contexts));
            Add(new SelfEventSystem<Model, Component.Suit>(contexts));
            Add(new SelfEventSystem<Model, Portrait>(contexts));
            Add(new SelfEventSystem<Model, Title>(contexts));
            Add(new SelfEventSystem<Model, Description>(contexts));
        }
    }
}