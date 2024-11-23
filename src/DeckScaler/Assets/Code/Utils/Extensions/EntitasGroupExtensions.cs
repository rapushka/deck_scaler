using System;
using Entitas;
using Entitas.Generic;

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
    }
}