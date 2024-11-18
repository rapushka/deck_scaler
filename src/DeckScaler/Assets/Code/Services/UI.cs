using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DeckScaler.Service
{
    public interface IUI : IService
    {
        void  Init();
        void  ShowMainMenu();
        void  ShowGameplayHUD();
        TView GetView<TView>();
        void  SetView(GameObject prefab);
    }

    public class UI : IUI
    {
        private Canvas _canvas;

        private GameObject _currentView;

        public void Init()
        {
            var canvasPrefab = Resources.Load<Canvas>("UI/Canvas/Canvas");
            _canvas = Object.Instantiate(canvasPrefab);
            _canvas.Init(Services.Get<ICameras>().UiCamera);
        }

        public void ShowMainMenu()
        {
            SetView(Resources.Load<GameObject>("UI/MainMenu/MainMenu"));
        }

        public void ShowGameplayHUD()
        {
            SetView(Resources.Load<GameObject>("UI/GameplayHUD/GameplayHUD"));
        }

        public TView GetView<TView>()
        {
            return _currentView.GetComponent<TView>()
                   ?? throw new InvalidOperationException($"Current view isn't the {typeof(TView).Name}");
        }

        public void SetView(GameObject prefab)
        {
            if (_currentView != null)
                Object.Destroy(_currentView);

            _currentView = Object.Instantiate(prefab, _canvas.Root);
        }
    }
}