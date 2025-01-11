using UnityEngine;

namespace DeckScaler
{
    public class GameplayViewBase : MonoBehaviour
    {
        public bool IsOpened => gameObject.IsActive();

        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
    }
}