using DeckScaler.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class TitleView : BaseListener<Model, Title>
    {
        [SerializeField] private TMP_Text _textMesh;

        public override void OnValueChanged(Entity<Model> entity, Title component)
        {
            _textMesh.text = component.Value;
        }
    }
}