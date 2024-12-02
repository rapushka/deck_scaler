using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace DeckScaler.Code.View.SortingOrder
{
    public class SortingGroupView : BaseListener<Game, SpriteSortOrder>
    {
        [SerializeField] private SortingGroup _sortingGroup;

        public override void OnValueChanged(Entity<Game> entity, SpriteSortOrder component)
            => _sortingGroup.sortingOrder = component.Value;
    }
}