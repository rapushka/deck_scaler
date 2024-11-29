using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    [RequireComponent(typeof(Collider2D))]
    public class HoverReceiver : MonoBehaviour
    {
        [SerializeField] private EntityBehaviour<Game> _entityBehaviour;

        private void OnMouseOver()
        {
            CreateEntity.Input()
                        .Add<HoveredEntity, EntityID>(_entityBehaviour.Entity.ID())
                        .Add<Destroy>()
                ;
        }
    }
}