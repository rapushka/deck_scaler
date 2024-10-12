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

		public void ShowMainMenu()
		{
			SetView(Resources.Load<GameObject>("UI/MainMenu/MainMenu"));
		}

		public void ShowGameplayHUD()
		{
			SetView(Resources.Load<GameObject>("UI/GameplayHUD/GameplayHUD"));
		}

		private void SetView(GameObject prefab)
		{
			if (_currentView != null)
				Object.Destroy(_currentView);

			_currentView = Object.Instantiate(prefab, _canvas.Root);
		}
	}
}