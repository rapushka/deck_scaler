using DeckScaler;
using UnityEngine;

namespace DeckScaler.Service
{
    public interface IInput : IService
    {
        Vector2 CursorWorldPosition { get; }
        bool    IsMousePressing     { get; }
    }

    public class UnityInput : IInput
    {
        private Camera MainCamera => Services.Get<ICameras>().MainCamera;

        public Vector2 CursorWorldPosition
            => MainCamera.Nullable()?.ScreenToWorldPoint(CursorScreenPosition).Flat()
               ?? Vector2.zero;

        public bool IsMousePressing => Input.GetMouseButton(0);

        private Vector2 CursorScreenPosition
            => Input.mousePosition.Flat();
    }
}