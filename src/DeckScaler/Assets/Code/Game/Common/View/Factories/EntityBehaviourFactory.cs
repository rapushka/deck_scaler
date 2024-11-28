using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class EntityBehaviourFactory
    {
        public EntityBehaviour<Game> Create(EntityBehaviour<Game> prefab)
        {
            return Setup(Object.Instantiate(prefab));
        }

        public EntityBehaviour<Game> Setup(EntityBehaviour<Game> view)
        {
            view.Register(Contexts.Instance);
            view.SetActive(false);

            view.Entity
                .Add<ID, EntityID>(EntityID.Next())
                .Add<View, EntityBehaviour<Game>>(view)
                .Add<ViewTransform, Transform>(view.transform)
                .Add<Loading>()
                ;

            return view;
        }
    }
}