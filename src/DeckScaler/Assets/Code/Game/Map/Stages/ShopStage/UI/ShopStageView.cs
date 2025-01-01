using UnityEngine;

namespace DeckScaler
{
    public class ShopStageView : MonoBehaviour
    {
        [field: SerializeField] public Transform UnitsRoot    { get; private set; }
        [field: SerializeField] public float     UnitsSpacing { get; private set; }

        [field: SerializeField] public Transform TrinketsRoot    { get; private set; }
        [field: SerializeField] public float     TrinketsSpacing { get; private set; }
        [SerializeField] private Transform _offscreenTransform;

        public Vector2 OffscreenPosition => _offscreenTransform.position;
    }
}