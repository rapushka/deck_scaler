using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IEntityBehaviourFactory
    {
        Entity<Game> Create(EntityBehaviour<Game> prefab, Vector2 spawnPosition);
        Entity<Game> Setup(EntityBehaviour<Game> view);
    }

    public class EntityBehaviourFactory : IEntityBehaviourFactory
    {
        private static IIdentifierServer Identifiers => ServiceLocator.Resolve<IIdentifierServer>();

        public Entity<Game> Create(EntityBehaviour<Game> prefab, Vector2 spawnPosition)
            => Setup(Object.Instantiate(prefab), spawnPosition);

        public Entity<Game> Setup(EntityBehaviour<Game> view) => Setup(view, view.transform.position);

        private Entity<Game> Setup(EntityBehaviour<Game> view, Vector2 spawnPosition)
        {
            view.Register(Contexts.Instance);
            view.SetActive(false);
            var viewTransform = view.transform;

            return view.Entity
                    .AddSafely<DebugName, string>(view.name)
                    .Add<ID, EntityID>(new(Identifiers.Next()))
                    .Add<View, EntityBehaviour<Game>>(view)
                    .Add<ViewTransform, Transform>(viewTransform)
                    .Add<WorldPosition, Vector2>(spawnPosition)
                    .Add<Loading>()
                ;
        }
    }
}