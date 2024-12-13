using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Service;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class MapView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentStreetTextMesh;
        [SerializeField] private string _currentStreetTemplate = "Current Street: {0}";

        [Header("Levels")]
        [SerializeField] private Transform _levelsContainer;
        [SerializeField] private LevelButton _levelButtonPrefab;

        private readonly List<LevelButton> _levelButtons = new();

        public bool IsOpened => gameObject.IsActive();

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void LoadCurrentStreet()
        {
            _currentStreetTextMesh.text = _currentStreetTemplate.Format(Progress.CurrentStreetIndex + 1);
            CreateLevelButtons();
        }

        public void Show()
        {
            UpdateCompletedLevels();
            gameObject.SetActive(true);
        }

        public void Hide() => gameObject.SetActive(false);

        public void SelectNextLevel()
        {
            CreateEntity.OneFrame()
                .Add<SelectNextLevel>()
                ;
        }

        private void CreateLevelButtons()
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

        private void UpdateCompletedLevels()
        {
            foreach (var levelButton in _levelButtons)
                levelButton.UpdateState(Progress.CurrentLevelIndex);
        }

        private void ClearLevelButtons()
        {
            foreach (var levelButton in _levelButtons)
                Destroy(levelButton);
            _levelButtons.Clear();
        }
    }
}