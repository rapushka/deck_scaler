using UnityEngine;

namespace DeckScaler.Service
{
	public class UI
	{
		private Canvas _canvas;

		private GameObject _currentView;

		public void Init()
		{
			var canvasPrefab = Resources.Load<Canvas>("UI/Canvas/Canvas");
			_canvas = Object.Instantiate(canvasPrefab);
			_canvas.Init(Services.Instance.Cameras.UiCamera);
		}

		public void OpenMainMenu()
		{
			var mainMenuPrefab = Resources.Load<GameObject>("UI/MainMenu/MainMenu");
			ClearPreviousView();
			_currentView = Object.Instantiate(mainMenuPrefab, _canvas.Root);
		}

		private void ClearPreviousView()
		{
			if (_currentView != null)
				Object.Destroy(_currentView);
		}
	}
}