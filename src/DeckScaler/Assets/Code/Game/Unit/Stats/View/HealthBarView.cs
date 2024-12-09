using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class HealthBarView
        : BaseListener<Game>,
          IRegistrableListener<Game, Health>,
          IRegistrableListener<Game, MaxHealth>
    {
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private TMP_Text _text;

        private Entity<Game> _entity;

        public override void Register(Entity<Game> entity)
        {
            _entity = entity;
            _entity.Retain(this);

            _entity.AddListener<Health>(this);
            _entity.AddListener<MaxHealth>(this);

            if (_entity.Has<Health>() && _entity.Has<MaxHealth>())
                UpdateValue(_entity);
        }

        public void OnValueChanged(Entity<Game> entity, Health component)    => UpdateValue(entity);
        public void OnValueChanged(Entity<Game> entity, MaxHealth component) => UpdateValue(entity);

        private void UpdateValue(Entity<Game> entity)
        {
            var currentHP = entity.Get<Health>().Value;
            var maxHP = entity.Get<MaxHealth>().Value;

            _progressBar.NormalizedValue = (float)currentHP / maxHP;
            _text.text = $"{currentHP}/{maxHP}";
        }

        public override void Unregister()
        {
            _entity.AddListener<Health>(this);
            _entity.AddListener<MaxHealth>(this);

            _entity.Release(this);
            _entity = null;
        }
    }
}