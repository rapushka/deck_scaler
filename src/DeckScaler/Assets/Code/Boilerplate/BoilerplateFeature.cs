using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class BoilerplateFeature : Feature
    {
        public BoilerplateFeature(Contexts contexts)
            : base(nameof(BoilerplateFeature))
        {
            Add(new SelfEventSystem<Game, Stats>(contexts));
            Add(new SelfEventSystem<Game, Opponent>(contexts));
            Add(new SelfEventSystem<Game, Health>(contexts));
            Add(new SelfEventSystem<Game, Component.Suit>(contexts));
        }
    }
}