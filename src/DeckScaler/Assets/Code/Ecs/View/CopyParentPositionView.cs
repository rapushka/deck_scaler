using DeckScaler.Component;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class CopyParentPositionView : BaseListener<Model, Parent>
    {
        [SerializeField] private Transform _transform;

        public override void OnValueChanged(Entity<Model> entity, Parent component)
        {
            _transform.position = component.Value.position;
        }
    }
}