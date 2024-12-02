using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class InteractableButtonView : BaseListener<Game, Interactable>
    {
        [SerializeField] private Button _button;

        public override void OnValueChanged(Entity<Game> entity, Interactable component)
            => _button.interactable = entity.Is<Interactable>();
    }
}