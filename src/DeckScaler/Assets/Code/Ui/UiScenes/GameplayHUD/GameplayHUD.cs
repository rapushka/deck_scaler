using UnityEngine;

namespace DeckScaler
{
    public class GameplayHUD : UiScene
    {
        [field: SerializeField] public Transform TeamContainer { get; private set; }
    }
}