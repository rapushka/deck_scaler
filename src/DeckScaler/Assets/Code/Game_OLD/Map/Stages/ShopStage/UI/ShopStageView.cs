using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class ShopStageView : GameplayViewBase
    {
        [SerializeField] private Transform _offscreenTransform;

        [field: Header("Units")]
        [field: SerializeField] public Transform UnitsRoot { get; private set; }

        [field: SerializeField] public float UnitsSpacing { get; private set; }

        [field: Header("Trinkets")]
        [field: SerializeField] public Transform TrinketsRoot { get; private set; }

        [field: SerializeField] public float TrinketsSpacing { get; private set; }

        [field: Header("Reroll")]
        [field: SerializeField] public EntityBehaviour<Game> RerollButton { get; private set; }

        public Vector2 OffscreenPosition => _offscreenTransform.position;
    }
}