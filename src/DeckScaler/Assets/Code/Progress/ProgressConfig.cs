using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(ProgressConfig))]
    public class ProgressConfig : ScriptableObject
    {
        [field: SerializeField] public ProgressData NewProgressData { get; private set; }
    }
}