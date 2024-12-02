using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class BoilerplateFeature : Feature
    {
        public BoilerplateFeature(Contexts contexts)
            : base(nameof(BoilerplateFeature))
        {
            Add(new SelfFlagEventSystem<Game, Interactable>(contexts));
            Add(new SelfEventSystem<Game, SpriteSortOrder>(contexts));

            Add(new SelfEventSystem<Game, Component.Suit>(contexts));
            Add(new SelfEventSystem<Game, UnitID>(contexts));

            Add(new SelfEventSystem<Game, Health>(contexts));
            Add(new SelfEventSystem<Game, MaxHealth>(contexts));
            Add(new SelfEventSystem<Game, Damage>(contexts));
            Add(new SelfEventSystem<Game, Power>(contexts));
        }
    }
}