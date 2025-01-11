using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public static class AnimatableMovementExtensions
    {
        public static Entity<Game> SetPositionAnimatable(this Entity<Game> @this, Vector2 newPosition)
        {
            if (@this.Is<AnimateMovement>())
                @this.Replace<TargetPosition, Vector2>(newPosition);
            else
                @this.Replace<WorldPosition, Vector2>(newPosition);

            return @this;
        }
    }
}