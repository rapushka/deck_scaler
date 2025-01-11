using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Cursor = DeckScaler.Component.Cursor;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler
{
    public sealed class UpdateCursorMoveDelta : IExecuteSystem
    {
        private readonly IGroup<Entity<Input>> _cursors
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<Cursor>()
                    .And<WorldPosition>()
                    .Build()
            );

        private static IInput Input => ServiceLocator.Resolve<IInput>();

        public void Execute()
        {
            foreach (var cursor in _cursors)
            {
                var nextWorldPosition = Input.CursorWorldPosition;
                var prevWorldPosition = cursor.Get<WorldPosition, Vector2>();

                var delta = nextWorldPosition - prevWorldPosition;
                cursor.Replace<MoveDelta, Vector2>(delta);
            }
        }
    }
}