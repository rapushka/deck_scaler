using System;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using JetBrains.Annotations;

namespace DeckScaler
{
    public static class EntitasGroupMinMaxExtensions
    {
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

        public static int Max(this IGroup<Entity<Game>> @this, Func<Entity<Game>, int> selector)
        {
            var max = (int?)null;

            foreach (var entity in @this)
            {
                var value = selector(entity);

                if (max is null || max < value)
                    max = value;
            }

            return max ?? throw new InvalidOperationException("Group is empty!");
        }
    }
}