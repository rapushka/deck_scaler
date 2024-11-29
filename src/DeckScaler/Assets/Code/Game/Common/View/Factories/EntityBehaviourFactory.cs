using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class EntityBehaviourFactory
    {
        public EntityBehaviour<Game> Create(EntityBehaviour<Game> prefab) => Setup(Object.Instantiate(prefab));

        public EntityBehaviour<Game> Setup(EntityBehaviour<Game> view)
        {
            view.Register(Contexts.Instance);
            view.SetActive(false);
            var viewTransform = view.transform;

            view.Entity
                .Add<ID, EntityID>(EntityID.Next())
                .Add<View, EntityBehaviour<Game>>(view)
                .Add<ViewTransform, Transform>(viewTransform)
                .Add<WorldPosition, Vector2>(viewTransform.position)
                .Add<Loading>()
                ;

            return view;
        }
    }
}