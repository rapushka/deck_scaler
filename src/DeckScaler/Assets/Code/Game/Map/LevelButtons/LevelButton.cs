using System;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class LevelButton : BaseButton, IDisposable
    {
        [SerializeField] private TMP_Text _textMesh;
        [SerializeField] private GameObject _completedView;

        private int _buttonLevelIndex;
        private Entity<Game> _entity;

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static GameplayHUD HUD => UiMediator.GetCurrentScreen<GameplayHUD>();

        protected override void OnClick()
        {
            HUD.MapView.SelectNextLevel();
        }

        public void Initialize(Entity<Game> entity)
        {
            _entity = entity;
            _entity.Retain(this);

            var stageIndex = entity.Get<StageIndex, int>();
            _buttonLevelIndex = stageIndex;
            _textMesh.text = (_buttonLevelIndex + 1).ToString();

            UpdateState();
        }

        public void UpdateState()
        {
            Button.interactable = _entity.Is<CurrentStage>();
            _completedView.SetActive(_entity.Is<CompletedStage>());
        }

        public void Dispose()
        {
            _entity.Release(this);
            _entity = null;
        }
    }
}