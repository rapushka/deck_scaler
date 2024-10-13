using DeckScaler.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class TitleView : BaseListener<Scope, Title>
    {
        [SerializeField] private TMP_Text _textMesh;

        public override void OnValueChanged(Entity<Scope> entity, Title component)
        {
            _textMesh.text = component.Value;
        }
    }
}