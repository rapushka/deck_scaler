using DeckScaler.Service;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class CheatsInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;

        private string _lastCheat;

        private void OnEnable() => _inputField.Select();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                SendCheat();

            if (Input.GetKeyDown(KeyCode.UpArrow))
                RestorePreviousCheat();
        }

        private void SendCheat()
        {
            var cheat = _inputField.text;
            if (cheat.IsEmpty())
                return;

            ServiceLocator.Resolve<IUiMediator>().SendCheat(cheat);
            _lastCheat = cheat;
            Clear();
        }

        private void RestorePreviousCheat()
        {
            _inputField.text = _lastCheat;
        }

        public void Clear()
        {
            _inputField.text = string.Empty;
        }
    }
}