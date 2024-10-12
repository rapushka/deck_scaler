using Entitas.Generic;

namespace DeckScaler
{
    public sealed class MainFeature : Feature
    {
        public MainFeature()
            : base(nameof(MainFeature))
        {
            Add(new BoilerplateFeature(Contexts.Instance));
        }
    }
}