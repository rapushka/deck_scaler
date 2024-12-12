using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + "Trinkets/Config")]
    public class TrinketConfig : ScriptableObject
    {
        [field: SerializeField] public TrinketIDRef ID { get; private set; }

        [field: SerializeField] public AffectData Affect { get; private set; }
        [field: SerializeField] public int        Price  { get; private set; }
    }
}