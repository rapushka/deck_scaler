using DeckScaler.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class DescriptionView : BaseListener<View, Description>
    {
        [SerializeField] private TMP_Text _textMesh;

        public override void OnValueChanged(Entity<View> entity, Description component)
        {
            _textMesh.text = component.Value;
        }
    }
}