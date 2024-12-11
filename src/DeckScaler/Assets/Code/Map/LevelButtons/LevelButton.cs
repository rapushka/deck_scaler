using DeckScaler.Service;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class LevelButton : BaseButton
    {
        [SerializeField] private TMP_Text _textMesh;
        [SerializeField] private GameObject _completedView;

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static GameplayHUD HUD => UiMediator.GetCurrentScreen<GameplayHUD>();

        protected override void OnClick()
        {
            HUD.MapView.SelectNextLevel();
        }

        public void Initialize(int buttonLevelIndex, int currentLevelIndex)
        {
            _textMesh.text = (buttonLevelIndex + 1).ToString();

            Button.interactable = currentLevelIndex == buttonLevelIndex;
            _completedView.SetActive(currentLevelIndex > buttonLevelIndex);
        }
    }
}