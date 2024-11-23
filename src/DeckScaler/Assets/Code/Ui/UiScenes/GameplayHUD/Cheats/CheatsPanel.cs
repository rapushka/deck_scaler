using UnityEngine;

namespace DeckScaler
{
    public class CheatsPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _container;

        private void Awake() => SetActive(false);

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tilde) || Input.GetKeyDown(KeyCode.BackQuote))
                ToggleVisibility();
        }
#endif

        private void ToggleVisibility() => SetActive(!_container.activeSelf);

        private void SetActive(bool value) => _container.SetActive(value);
    }
}