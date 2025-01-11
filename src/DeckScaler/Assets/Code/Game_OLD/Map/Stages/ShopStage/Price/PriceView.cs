using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class PriceView : BaseListener<Game, Price>
    {
        [SerializeField] private TMP_Text _textMesh;

        public override void OnValueChanged(Entity<Game> entity, Price component)
            => _textMesh.text = $"${component.Value}";
    }
}