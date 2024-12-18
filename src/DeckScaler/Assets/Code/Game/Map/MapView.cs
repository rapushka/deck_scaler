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
        [SerializeField] private string _currentStreetTemplate = "Current Street: {0}/{1}";

        [Header("Levels")]
        [SerializeField] private Transform _levelsContainer;
        [SerializeField] private LevelButton _levelButtonPrefab;

        private readonly List<LevelButton> _levelButtons = new();

        public bool IsOpened => gameObject.IsActive();

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void LoadCurrentStreet()
        {
            var currentStreetNumber = Progress.CurrentStreetIndex + 1;
            var totalStreetCount = Config.CountOfStreets;

            _currentStreetTextMesh.text = _currentStreetTemplate.Format(currentStreetNumber, totalStreetCount);
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

            var currentLevelIndex = Progress.CurrentStageIndex;

            for (var i = 0; i < Config.CountOfStagesOnStreet; i++)
            {
                var levelButton = Instantiate(_levelButtonPrefab, _levelsContainer);
                levelButton.Initialize(i, currentLevelIndex);
                _levelButtons.Add(levelButton);
            }
        }

        private void UpdateCompletedLevels()
        {
            foreach (var levelButton in _levelButtons)
                levelButton.UpdateState(Progress.CurrentStageIndex);
        }

        private void ClearLevelButtons()
        {
            foreach (var levelButton in _levelButtons)
                levelButton.DestroyObject();
            _levelButtons.Clear();
        }
    }
}