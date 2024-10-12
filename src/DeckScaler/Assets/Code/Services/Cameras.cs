using UnityEngine;

namespace DeckScaler.Service
{
	public class Cameras
	{
		public Cameras(Camera mainCamera, Camera uiCamera)
		{
			MainCamera = mainCamera;
			UiCamera = uiCamera;
		}

		public Camera MainCamera { get; }
		public Camera UiCamera   { get; }
	}
}