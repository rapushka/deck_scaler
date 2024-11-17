using SmartIdTable;
using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(SpriteSheet))]
    public class SpriteSheet : ScriptableObject
    {
        [field: SerializeField] public SerializedDictionary<UnitIDRef, Sprite> UnitPortraits   { get; private set; }
        [field: SerializeField] public SerializedDictionary<Suit, Sprite>      CardBackgrounds { get; private set; }
    }
}