using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler.Component
{
    public class HealthView : BaseListener<Scope, Health>
    {
        [SerializeField] private TMP_Text _text;

        public override void OnValueChanged(Entity<Scope> entity, Health component)
        {
            _text.text = component.Value.ToString();
        }
    }
}