using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
	[RequireComponent(typeof(Button))]
	public abstract class BaseButton : MonoBehaviour
	{
		private Button _button;

		private void OnEnable()
		{
			_button ??= GetComponent<Button>();
			_button.onClick.AddListener(OnClick);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnClick);
		}

		protected abstract void OnClick();
	}
}