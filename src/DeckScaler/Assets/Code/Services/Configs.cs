using Code.Utils;
using UnityEngine;

namespace DeckScaler.Service
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(Configs))]
    public class Configs : ScriptableObject
    {
        [field: SerializeField] public UnitViewsConfig UnitViews { get; private set; }
    }
}