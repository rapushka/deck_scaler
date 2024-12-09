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

        private static UiConfig Config => ServiceLocator.Resolve<IConfigs>().Ui;

        private static ICameras Cameras => ServiceLocator.Resolve<ICameras>();

        public void Init()
        {
            _uiCanvas = Object.Instantiate(Config.CanvasPrefab);
            _uiCanvas.Init(Cameras.UiCamera);
        }

        public void ShowMainMenu() => SetView(Config.MainMenu);

        public void ShowGameplayHUD() => SetView(Config.GameplayHUD);

        public TScene GetScene<TScene>()
            where TScene : UiScene
            => _currentView.GetComponent<TScene>()
                ?? throw new InvalidOperationException($"Current view isn't the {typeof(TScene).Name}");

        public void SetView(GameObject prefab)
        {
            _currentView?.DestroyObject();
            _currentView = Object.Instantiate(prefab, _uiCanvas.Root);
        }
    }
}