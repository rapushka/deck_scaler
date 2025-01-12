using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IEntityBehaviourFactory
    {
        Entity<Game> Create(EntityBehaviour<Game> prefab, Vector2 spawnPosition);
        Entity<Game> Register(EntityBehaviour<Game> view);
    }

    public class EntityBehaviourFactory : IEntityBehaviourFactory
    {
        private static IIdentifierServer Identifiers => ServiceLocator.Resolve<IIdentifierServer>();

        public Entity<Game> Create(EntityBehaviour<Game> prefab, Vector2 spawnPosition)
            => Register(Object.Instantiate(prefab), spawnPosition);

        public Entity<Game> Register(EntityBehaviour<Game> view) => Register(view, view.transform.position);

        private Entity<Game> Register(EntityBehaviour<Game> view, Vector2 spawnPosition)
        {
            view.Register(Contexts.Instance);
            var viewTransform = view.transform;

            return view.Entity
                    .Add<Initializing>()
                    .AddSafely<DebugName, string>(view.name)
                    .Add<ID, EntityID>(new(Identifiers.Next()))
                    .Add<View, EntityBehaviour<Game>>(view)
                    .Add<ViewTransform, Transform>(viewTransform)
                    .Add<WorldPosition, Vector2>(spawnPosition)
                ;
        }
    }
}