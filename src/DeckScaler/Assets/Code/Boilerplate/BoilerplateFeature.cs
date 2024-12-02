using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class BoilerplateFeature : Feature
    {
        public BoilerplateFeature()
            : base(nameof(BoilerplateFeature))
        {
            Add(new SelfFlagEventSystem<Game, Interactable>(Contexts.Instance));
        }
    }
}