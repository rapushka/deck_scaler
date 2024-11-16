using DeckScaler.Systems;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class MainFeature : Feature
    {
        public MainFeature()
            : base(nameof(MainFeature))
        {
            Add(new LoadViewsForEntities());
            Add(new LoadUnitPortrait());
            Add(new LoadCardBackgroundsPortrait());
            Add(new MarkLoaded());

            Add(new BoilerplateFeature(Contexts.Instance));
        }
    }
}