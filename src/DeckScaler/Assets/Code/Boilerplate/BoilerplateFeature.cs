using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class BoilerplateFeature : Feature
    {
        public BoilerplateFeature(Contexts contexts)
            : base(nameof(BoilerplateFeature))
        {
            Add(new SelfEventSystem<Scope, Stats>(contexts));
            Add(new SelfEventSystem<Scope, Opponent>(contexts));
            Add(new SelfEventSystem<Scope, Health>(contexts));
            Add(new SelfEventSystem<Scope, Component.Suit>(contexts));
            Add(new SelfEventSystem<Scope, Portrait>(contexts));
        }
    }
}