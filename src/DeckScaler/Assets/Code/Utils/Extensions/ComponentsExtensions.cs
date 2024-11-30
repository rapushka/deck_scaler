using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public static class ComponentsExtensions
    {
        public static Entity<Game> ReplaceIfDifferent<TComponent, TValue>(this Entity<Game> @this, TValue newValue)
            where TComponent : ValueComponent<TValue>, IInScope<Game>, new()
        {
            if (@this.TryGet<TComponent>(out var oldValue)
                && oldValue.Equals(newValue))
                return @this;

            @this.Replace<TComponent, TValue>(newValue);
            return @this;
        }
    }
}