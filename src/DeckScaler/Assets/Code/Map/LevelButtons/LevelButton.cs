using DeckScaler.Service;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class LevelButton : BaseButton
    {
        [SerializeField] private TMP_Text _textMesh;

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static GameplayHUD HUD => UiMediator.GetCurrentScreen<GameplayHUD>();

        protected override void OnClick()
        {
            HUD.MapView.SelectNextLevel();
        }

        public void Initialize(int levelIndex, int currentLevelIndex)
        {
            _textMesh.text = (levelIndex + 1).ToString();

            Button.interactable = levelIndex == currentLevelIndex;
            Button.enabled = levelIndex >= currentLevelIndex;
        }
    }
}