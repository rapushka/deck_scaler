using System;
using Object = UnityEngine.Object;

namespace DeckScaler.Service
{
    public interface IUiScreens : IService
    {
        void Init();

        TView GetCurrent<TView>() where TView : BaseUiScreen;

        void Open<TView>() where TView : BaseUiScreen;
    }

    public class UiScreens : IUiScreens
    {
        private UiCanvas _uiCanvas;

        private BaseUiScreen _currentScreen;

        private static UiConfig Config => ServiceLocator.Resolve<IConfigs>().Ui;

        private static ICameras Cameras => ServiceLocator.Resolve<ICameras>();

        public void Init()
        {
            _uiCanvas = Object.Instantiate(Config.CanvasPrefab);
            _uiCanvas.Init(Cameras.UiCamera);
        }

        public void Open<TScreen>() where TScreen : BaseUiScreen => SetView(Config.Screens.Get<TScreen>());

        public TScene GetCurrent<TScene>()
            where TScene : BaseUiScreen
            => _currentScreen as TScene
                ?? throw new InvalidOperationException($"Current view is {_currentScreen.GetType().Name} But requested {typeof(TScene).Name}");

        private void SetView(BaseUiScreen prefab)
        {
            _currentScreen?.DestroyObject();
            _currentScreen = Object.Instantiate(prefab, _uiCanvas.Root);
        }
    }
}