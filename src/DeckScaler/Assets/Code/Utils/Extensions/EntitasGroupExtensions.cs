using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public static class EntitasGroupExtensions
    {
        public static bool Any<TScope>(this IGroup<Entity<TScope>> @this)
            where TScope : IScope
            => @this.count > 0;
    }
}