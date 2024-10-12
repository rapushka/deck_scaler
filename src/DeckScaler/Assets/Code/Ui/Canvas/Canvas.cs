using UnityEngine;

namespace DeckScaler
{
	public class Canvas : MonoBehaviour
	{
		[SerializeField] private UnityEngine.Canvas _canvas;

		[field: SerializeField] public Transform Root { get; private set; }

		public void Init(Camera uiCamera)
		{
			_canvas.worldCamera = uiCamera;
		}
	}
}