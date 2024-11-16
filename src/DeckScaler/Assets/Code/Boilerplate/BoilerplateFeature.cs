using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class BoilerplateFeature : Feature
    {
        public BoilerplateFeature(Contexts contexts)
            : base(nameof(BoilerplateFeature))
        {
            Add(new SelfEventSystem<Model, Stats>(contexts));
            Add(new SelfEventSystem<Model, Opponent>(contexts));
            Add(new SelfEventSystem<Model, Health>(contexts));
            Add(new SelfEventSystem<Model, Component.Suit>(contexts));
            Add(new SelfEventSystem<View, Parent>(contexts));
            Add(new SelfEventSystem<View, Portrait>(contexts));
        }
    }
}