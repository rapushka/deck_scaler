using DeckScaler.Component;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class OpponentView : BaseListener<Scope, Opponent>
    {
        [SerializeField] private Transform _opponentHolder;
        

        public override void OnValueChanged(Entity<Scope> entity, Opponent component)
        {
            if (!entity.Is<Ally>())
                return;

            var opponentTransform = component.Value.Get<ViewTransform>().Value;
            opponentTransform.SetParent(_opponentHolder, worldPositionStays: false);
        }
    }
}