using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + "Trinkets/Config")]
    public class TrinketConfig : ScriptableObject
    {
        [field: SerializeField] public TrinketIDRef TrinketID { get; private set; }

        [field: SerializeField] public AffectData Affect { get; private set; }
        [field: SerializeField] public int        Price  { get; private set; }

        [Header("View")]
        [field: SerializeField] public string Name { get; private set; }

        [field: NaughtyAttributes.ShowAssetPreview]
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}