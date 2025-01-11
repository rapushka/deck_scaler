using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
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

        public static IEnumerable<Entity<TScope>> Where<TScope>(this IGroup<Entity<TScope>> @this, Func<Entity<TScope>, bool> predicate)
            where TScope : IScope
        {
            foreach (var entity in @this)
            {
                if (predicate.Invoke(entity))
                    yield return entity;
            }
        }
    }
}