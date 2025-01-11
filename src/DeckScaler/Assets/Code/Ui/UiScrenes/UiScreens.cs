using System;
using Object = UnityEngine.Object;

namespace DeckScaler.Service
{
    public interface IUiScreens : IService
    {
        void Init();

        TView GetCurrent<TView>() where TView : BaseUiScreen;

        TView Open<TView>() where TView : BaseUiScreen;
        void  DisposeCurrent();
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

        public TScreen Open<TScreen>() where TScreen : BaseUiScreen => (TScreen)SetView(Config.Screens.Get<TScreen>());

        public TScene GetCurrent<TScene>()
            where TScene : BaseUiScreen
            => _currentScreen as TScene
                ?? throw new InvalidOperationException($"Current view is {_currentScreen.GetType().Name} But requested {typeof(TScene).Name}");

        private BaseUiScreen SetView(BaseUiScreen prefab)
        {
            _currentScreen?.DestroyObject();
            _currentScreen = Object.Instantiate(prefab, _uiCanvas.Root);
            return _currentScreen;
        }

        public void DisposeCurrent()
        {
            (_currentScreen as IDisposable)?.Dispose();
        }
    }
}