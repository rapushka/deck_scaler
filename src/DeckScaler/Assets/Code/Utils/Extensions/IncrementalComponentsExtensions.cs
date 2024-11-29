using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public static class IncrementalComponentsExtensions
    {
        public static Entity<Game> Increment<TComponent>(this Entity<Game> entity, ValueComponent<Vector2> otherComponent)
            where TComponent : ValueComponent<Vector2>, IInScope<Game>, new()
            => entity.Increment<TComponent>(otherComponent.Value);

        public static Entity<Game> Increment<TComponent>(this Entity<Game> entity, Vector2 value)
            where TComponent : ValueComponent<Vector2>, IInScope<Game>, new()
            => entity.Replace<TComponent, Vector2>(entity.Get<TComponent>().Value + value);
    }
}