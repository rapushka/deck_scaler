using DeckScaler.Service;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class CheatsInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;

        private void OnEnable() => _inputField.Select();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Services.Get<IUiMediator>().SendCheat(_inputField.text);
                Clear();
            }
        }

        public void Clear()
        {
            _inputField.text = string.Empty;
        }
    }
}