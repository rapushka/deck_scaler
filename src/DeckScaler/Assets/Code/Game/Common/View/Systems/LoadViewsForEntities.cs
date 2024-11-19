using System.Collections.Generic;
using DeckScaler.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static DeckScaler.MatcherBuilder<DeckScaler.Game>;

namespace DeckScaler.Systems
{
    public class LoadViewsForEntities : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                With<PrefabToLoad>()
                    .Without<View>()
            );

        private readonly List<Entity<Game>> _buffer = new(16);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var prefab = entity.Get<PrefabToLoad>().Value;
                var view = Object.Instantiate(prefab);

                view.Register(entity);
                entity.Remove<PrefabToLoad>();

                entity
                    .Add<View, EntityBehaviour>(view)
                    .Add<ViewTransform, Transform>(view.transform)
                    ;
            }
        }
    }
}