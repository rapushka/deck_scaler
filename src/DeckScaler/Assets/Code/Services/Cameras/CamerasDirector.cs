using UnityEngine;

namespace DeckScaler.Service
{
    public class CamerasDirector : MonoBehaviour
    {
        [field: SerializeField] public Camera MainCamera { get; private set; }
        [field: SerializeField] public Camera UiCamera   { get; private set; }
    }
}