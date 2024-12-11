using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Service;
using UnityEngine;

namespace DeckScaler
{
    public class MapView : MonoBehaviour
    {
        [SerializeField] private Transform _levelsContainer;
        [SerializeField] private LevelButton _levelButtonPrefab;

        private readonly List<LevelButton> _levelButtons = new();

        public bool IsOpened => gameObject.IsActive();

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void LoadLevelsOnCurrentStreet()
        {
            ClearLevelButtons();

            var currentLevelIndex = Progress.CurrentLevelIndex;

            for (var i = 0; i < Config.CountOfLevelOnStreet; i++)
            {
                var levelButton = Instantiate(_levelButtonPrefab, _levelsContainer);
                levelButton.Initialize(i, currentLevelIndex);
                _levelButtons.Add(levelButton);
            }
        }

        public void Show()
        {
            UpdateCompletedLevels();
            gameObject.SetActive(true);
        }

        private void UpdateCompletedLevels()
        {
            foreach (var levelButton in _levelButtons)
            {
                levelButton.UpdateState(Progress.CurrentLevelIndex);
            }
        }

        public void Hide() => gameObject.SetActive(false);

        public void SelectNextLevel()
        {
            CreateEntity.OneFrame()
                .Add<SelectNextLevel>()
                ;
        }

        private void ClearLevelButtons()
        {
            foreach (var levelButton in _levelButtons)
                Destroy(levelButton);
            _levelButtons.Clear();
        }
    }
}