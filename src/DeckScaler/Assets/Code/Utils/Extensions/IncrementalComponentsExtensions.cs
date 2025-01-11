using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public static class IncrementalComponentsExtensions
    {
#region vector

        public static Entity<Game> Increment<TComponent>(this Entity<Game> entity, ValueComponent<Vector2> otherComponent)
            where TComponent : ValueComponent<Vector2>, IInScope<Game>, new()
            => entity.Increment<TComponent>(otherComponent.Value);

        public static Entity<Game> Increment<TComponent>(this Entity<Game> entity, Vector2 value)
            where TComponent : ValueComponent<Vector2>, IInScope<Game>, new()
            => entity.Replace<TComponent, Vector2>(entity.Get<TComponent>().Value + value);

#endregion

#region int

        public static Entity<Game> Increment<TComponent>(this Entity<Game> entity, ValueComponent<int> otherComponent)
            where TComponent : ValueComponent<int>, IInScope<Game>, new()
            => entity.Increment<TComponent>(otherComponent.Value);

        public static Entity<Game> Increment<TComponent>(this Entity<Game> entity, int value, int? min = null, int? max = null)
            where TComponent : ValueComponent<int>, IInScope<Game>, new()
        {
            var result = entity.Get<TComponent>().Value + value;
            return entity.Replace<TComponent, int>(result.Clamp(min, max));
        }

#endregion
    }
}