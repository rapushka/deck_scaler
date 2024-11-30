using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(UnitViewConfig))]
    public class UnitViewConfig : ScriptableObject
    {
        [field: SerializeField] public Vector2 TeammateSpawnOffset { get; private set; }
        [field: SerializeField] public Vector2 EnemySpawnOffset    { get; private set; }

        [field: SerializeField] public float AppearDuration { get; private set; }
    }
}