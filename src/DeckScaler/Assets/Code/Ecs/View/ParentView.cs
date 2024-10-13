using DeckScaler.Component;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class ParentView : BaseListener<Scope, Parent>
    {
        [SerializeField] private Transform _transform;

        public override void OnValueChanged(Entity<Scope> entity, Parent component)
        {
            _transform.SetParent(component.Value);
        }
    }
}