using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseButton : MonoBehaviour
    {
        private Button _button;

        protected Button Button => _button ??= GetComponent<Button>();

        private void OnEnable() => Button.onClick.AddListener(OnClick);

        private void OnDisable() => Button.onClick.RemoveListener(OnClick);

        protected abstract void OnClick();
    }
}