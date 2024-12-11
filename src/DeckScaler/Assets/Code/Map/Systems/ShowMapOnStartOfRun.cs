using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class ShowMapOnStartOfRun : IInitializeSystem
    {
        private readonly IGroup<Entity<Game>> _maps
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Map>()
                    .Build()
            );

        public void Initialize()
        {
            foreach (var map in _maps)
            {
                map
                    .Is<Visible>(true)
                    .Is<Interactable>(true)
                    ;
            }
        }
    }
}