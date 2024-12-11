using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseButton : MonoBehaviour
    {
        protected Button Button { get; private set; }

        private void OnEnable()
        {
            Button ??= GetComponent<Button>();
            Button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(OnClick);
        }

        protected abstract void OnClick();
    }
}