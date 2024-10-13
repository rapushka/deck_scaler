using UnityEngine;

namespace DeckScaler.Ui.Views.GameplayHUD
{
    public class GameplayHUD : MonoBehaviour
    {
        [field: SerializeField] public CardsHolder CardsHolder { get; private set; }
    }
}