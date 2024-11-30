using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DeckScaler
{
    public class UiHoverReceiver : MonoBehaviour, IPointerMoveHandler
    {
        [SerializeField] private EntityBehaviour<Game> _entityBehaviour;

        public void OnPointerMove(PointerEventData eventData)
        {
            CreateEntity.Input()
                .Add<HoveredEntity, EntityID>(_entityBehaviour.Entity.ID())
                .Add<Destroy>()
                ;
        }
    }
}