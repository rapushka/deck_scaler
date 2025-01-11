using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;
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

        private static MapUtils Utils => ServiceLocator.Resolve<IUtils>().Map;

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;
        private static MapConfig    Config   => ServiceLocator.Resolve<IConfigs>().Map;

        private static PrimaryEntityIndex<Game, StageIndex, int> Index
            => Contexts.Instance.Get<Game>().GetPrimaryIndex<StageIndex, int>();

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

        public void Dispose() => ClearLevelButtons();

        private void CreateLevelButtons()
        {
            ClearLevelButtons();

            foreach (var stageEntity in Utils.GetStagesInOrder())
            {
                var stageButton = Instantiate(_levelButtonPrefab, _levelsContainer);
                stageButton.Initialize(stageEntity);
                stageButton.Clicked += OnStageSelected;
                _levelButtons.Add(stageButton);
            }
        }

        private void OnStageSelected(int stageIndex)
        {
            Index.GetEntity(stageIndex)
                .Add<SelectStage>()
                ;
        }

        private void UpdateCompletedLevels()
        {
            foreach (var levelButton in _levelButtons)
                levelButton.UpdateState();
        }

        private void ClearLevelButtons()
        {
            foreach (var levelButton in _levelButtons)
                levelButton.DestroyObject();
            _levelButtons.Clear();
        }
    }
}