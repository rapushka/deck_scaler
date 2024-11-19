using DeckScaler.Component;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class EntityBehaviourFactory
    {
        public EntityBehaviour Create(EntityBehaviour prefab)
        {
            var view = Object.Instantiate(prefab);
            view.Register(Contexts.Instance);

            view.Entity
                .Add<ID, EntityID>(EntityID.Next())
                .Add<View, EntityBehaviour>(view)
                .Add<ViewTransform, Transform>(view.transform)
                .Add<Loading>()
                ;

            return view;
        }
    }
}