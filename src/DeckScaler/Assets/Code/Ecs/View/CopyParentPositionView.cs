using DeckScaler.Component;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class CopyParentPositionView : BaseListener<Scope, Parent>
    {
        [SerializeField] private Transform _transform;

        public override void OnValueChanged(Entity<Scope> entity, Parent component)
        {
            _transform.position = component.Value.position;
        }
    }
}