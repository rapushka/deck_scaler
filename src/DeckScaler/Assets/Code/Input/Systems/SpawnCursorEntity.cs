using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using UnityEngine;
using Cursor = DeckScaler.Component.Cursor;

namespace DeckScaler.Systems
{
    public sealed class SpawnCursorEntity : IInitializeSystem
    {
        private static Vector2 CursorWorldPosition => Services.Get<IInput>().CursorWorldPosition;

        public void Initialize()
        {
            CreateEntity.Input()
                        .Is<Cursor>(true)
                        .Add<WorldPosition, Vector2>(CursorWorldPosition)
                ;
        }
    }
}