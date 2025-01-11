using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace DeckScaler
{
    public class SimpleTextViewBase<TScope, TComponent> : BaseListener<TScope, TComponent>
        where TScope : IScope
        where TComponent : ValueComponent<int>, IInScope<TScope>, IEvent, new()
    {
        [SerializeField] private TMP_Text _textMesh;

        public override void OnValueChanged(Entity<TScope> entity, TComponent component)
            => _textMesh.text = component.Value.ToString();
    }
}