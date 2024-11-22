using SmartIdTable;
using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(UnitConfig))]
    public class UnitConfig : ScriptableObject
    {
        [field: IdRef(startsWith: Constants.TableID.Units)]
        [field: SerializeField] public string ID { get; private set; }

        [field: SerializeField] public UnitType  Type       { get; private set; }
        [field: SerializeField] public int       Health     { get; private set; }
        [field: SerializeField] public int       BaseDamage { get; private set; }
        [field: SerializeField] public Suit      Suit       { get; private set; }
        [field: SerializeField] public StatsData StatsData  { get; private set; }
    }
}