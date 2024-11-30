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
        TView GetScene<TView>() where TView : UiScene;
        void  SetView(GameObject prefab);
    }

    public class UI : IUI
    {
        private UiCanvas _uiCanvas;

        private GameObject _currentView;

        public void Init()
        {
            var canvasPrefab = Resources.Load<UiCanvas>("UI/Canvas/Canvas");
            _uiCanvas = Object.Instantiate(canvasPrefab);
            _uiCanvas.Init(Services.Get<ICameras>().UiCamera);
        }

        public void ShowMainMenu()
        {
            SetView(Resources.Load<GameObject>("UI/MainMenu/MainMenu"));
        }

        public void ShowGameplayHUD()
        {
            SetView(Resources.Load<GameObject>("UI/GameplayHUD/GameplayHUD"));
        }

        public TScene GetScene<TScene>()
            where TScene : UiScene
        {
            return _currentView.GetComponent<TScene>()
                   ?? throw new InvalidOperationException($"Current view isn't the {typeof(TScene).Name}");
        }

        public void SetView(GameObject prefab)
        {
            if (_currentView != null)
                Object.Destroy(_currentView);

            _currentView = Object.Instantiate(prefab, _uiCanvas.Root);
        }
    }
}