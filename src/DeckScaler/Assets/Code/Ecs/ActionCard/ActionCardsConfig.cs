using DeckScaler.Utils;
using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(ActionCardsConfig))]
    public class ActionCardsConfig : ScriptableObject
    {
        [SerializeField] private EntityBehaviour _cardVewPrefab;
        // [SerializeField] private SerializableDictionary<string, EntityConfig> _configs;

        public EntityBehaviour LoadView(string id)
        {
            var view = _cardVewPrefab.Spawn();
            // var config = _configs[id];
            // config.Setup(view.Entity);

            return view;
        }
    }
}