using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class EntityBehaviourFactory
    {
        public EntityBehaviour<Game> Create(EntityBehaviour<Game> prefab, Vector2 spawnPosition)
            => Setup(Object.Instantiate(prefab), spawnPosition);

        public EntityBehaviour<Game> Setup(EntityBehaviour<Game> view) => Setup(view, view.transform.position);

        public EntityBehaviour<Game> Setup(EntityBehaviour<Game> view, Vector2 spawnPosition)
        {
            view.Register(Contexts.Instance);
            view.SetActive(false);
            var viewTransform = view.transform;

            view.Entity
                .AddSafely<DebugName, string>(view.name)
                .Add<ID, EntityID>(EntityID.Next())
                .Add<View, EntityBehaviour<Game>>(view)
                .Add<ViewTransform, Transform>(viewTransform)
                .Add<WorldPosition, Vector2>(spawnPosition)
                .Add<Loading>()
                ;

            return view;
        }
    }
}