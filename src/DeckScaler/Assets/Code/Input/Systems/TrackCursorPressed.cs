using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using Cursor = DeckScaler.Component.Cursor;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler.Systems
{
    public sealed class TrackCursorPressed : IExecuteSystem
    {
        private readonly IGroup<Entity<Input>> _cursors
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<Cursor>()
                    .Build()
            );

        private static IInput Input => ServiceLocator.Get<IInput>();

        public void Execute()
        {
            foreach (var cursor in _cursors)
                cursor.Is<Pressed>(Input.IsMousePressing);
        }
    }
}