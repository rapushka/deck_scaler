using System;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using JetBrains.Annotations;

namespace DeckScaler.Systems
{
    public static class EntitasGroupExtensions
    {
        public static bool Any<TScope>(this IGroup<Entity<TScope>> @this)
            where TScope : IScope
            => @this.count > 0;

        public static bool Any<TScope>(this IGroup<Entity<TScope>> @this, Func<Entity<TScope>, bool> predicate)
            where TScope : IScope
        {
            foreach (var entity in @this)
            {
                if (predicate.Invoke(entity))
                    return true;
            }

            return false;
        }

        [CanBeNull]
        public static Entity<Game> MinByOrDefault<TComponent>(this IGroup<Entity<Game>> @this, Func<TComponent, float> selector)
            where TComponent : IComponent, IInScope<Game>, new()
            => @this.MinByOrDefault((e) => selector(e.Get<TComponent>()));

        [CanBeNull]
        public static Entity<TScope> MinByOrDefault<TScope>(this IGroup<Entity<TScope>> @this, Func<Entity<TScope>, float> selector)
            where TScope : IScope
        {
            float? min = null;
            Entity<TScope> minEntity = null;

            foreach (var entity in @this)
            {
                var value = selector(entity);

                if (min is null || min > value)
                {
                    min = value;
                    minEntity = entity;
                }
            }

            return minEntity;
        }
    }
}