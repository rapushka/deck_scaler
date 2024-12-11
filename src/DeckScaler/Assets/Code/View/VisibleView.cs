using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class VisibleView : BaseListener<Game, Visible>
    {
        [SerializeField] private GameObject _target;

        public override void OnValueChanged(Entity<Game> entity, Visible component)
            => _target.SetActive(entity.Is<Interactable>());
    }
}