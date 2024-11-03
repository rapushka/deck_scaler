using DeckScaler.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class TitleView : BaseListener<View, Title>
    {
        [SerializeField] private TMP_Text _textMesh;

        public override void OnValueChanged(Entity<View> entity, Title component)
        {
            _textMesh.text = component.Value;
        }
    }
}