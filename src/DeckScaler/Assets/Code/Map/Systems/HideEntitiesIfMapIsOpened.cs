using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class HideEntitiesIfMapIsOpened : IInitializeSystem, IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<HideMeWhenMapOpened>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _mapOpeningRequests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<OpenMapAfter>()
                    .Build()
            );

        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        public void Initialize()
        {
            foreach (var entity in _entities)
                entity.Is<Visible>(true); // TBD: #174
        }

        public void Execute()
        {
            foreach (var entity in _entities)
                entity.Is<Visible>(!HUD.MapView.IsOpened || _mapOpeningRequests.Any());
        }
    }
}