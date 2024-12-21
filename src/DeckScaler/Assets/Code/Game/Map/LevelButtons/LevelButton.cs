using System;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class LevelButton : BaseButton, IDisposable
    {
        [SerializeField] private TMP_Text _textMesh;
        [SerializeField] private GameObject _completedView;

        public event Action<int> Clicked;

        private int _stageIndex;
        private Entity<Game> _entity;

        protected override void OnClick() => Clicked?.Invoke(_stageIndex);

        public void Initialize(Entity<Game> entity)
        {
            _entity = entity;
            _entity.Retain(this);

            _stageIndex = entity.Get<StageIndex, int>();
            _textMesh.text = (_stageIndex + 1).ToString();

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

            Clicked = null;
        }
    }
}