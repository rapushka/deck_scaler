using DeckScaler.Service;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class LevelButton : BaseButton
    {
        [SerializeField] private TMP_Text _textMesh;
        [SerializeField] private GameObject _completedView;

        private int _buttonLevelIndex;

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static GameplayHUD HUD => UiMediator.GetCurrentScreen<GameplayHUD>();

        protected override void OnClick()
        {
            HUD.MapView.SelectNextLevel();
        }

        public void Initialize(int buttonLevelIndex, int currentLevelIndex)
        {
            _buttonLevelIndex = buttonLevelIndex;
            _textMesh.text = (_buttonLevelIndex + 1).ToString();

            UpdateState(currentLevelIndex);
        }

        public void UpdateState(int currentLevelIndex)
        {
            Button.interactable = currentLevelIndex == _buttonLevelIndex;
            _completedView.SetActive(currentLevelIndex > _buttonLevelIndex);
        }
    }
}