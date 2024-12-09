using UnityEngine;

namespace DeckScaler.Service
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(UiConfig))]
    public class UiConfig : ScriptableObject
    {
        [field: SerializeField] public UiCanvas CanvasPrefab { get; private set; }

        [field: Header("Pages")]
        [field: SerializeField] public GameObject MainMenu { get; private set; }

        [field: SerializeField] public GameObject GameplayHUD { get; private set; }
    }
}