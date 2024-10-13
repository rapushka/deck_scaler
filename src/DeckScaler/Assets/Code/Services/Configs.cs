using DeckScaler.Utils;
using UnityEngine;

namespace DeckScaler.Service
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(Configs))]
    public class Configs : ScriptableObject, IService
    {
        [field: SerializeField] public UnitsConfig      Units { get; private set; }
        [field: SerializeField] public ActionCardsConfig ActionCards { get; private set; }
    }
}