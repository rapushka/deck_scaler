using DeckScaler.Component;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class CopyParentPositionView : BaseListener<View, Parent>
    {
        [SerializeField] private Transform _transform;

        public override void OnValueChanged(Entity<View> entity, Parent component)
        {
            _transform.position = component.Value.position;
        }
    }
}