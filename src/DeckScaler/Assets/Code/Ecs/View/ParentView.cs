using DeckScaler.Component;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class ParentView : BaseListener<View, Parent>
    {
        [SerializeField] private Transform _transform;

        public override void OnValueChanged(Entity<View> entity, Parent component)
        {
            _transform.SetParent(component.Value, false);
        }
    }
}