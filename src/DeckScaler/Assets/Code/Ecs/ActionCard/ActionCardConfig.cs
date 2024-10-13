using DeckScaler.Utils;
using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(UnitsConfig))]
    public class ActionCardConfig : ScriptableObject
    {
        [SerializeField] private SerializableDictionary<string, EntityBehaviour> _configs;

        public EntityBehaviour Load(string id)
        {
            return _configs[id].Spawn();
        }
    }
}