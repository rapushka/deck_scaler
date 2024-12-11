using DeckScaler.Component;
using UnityEngine;

namespace DeckScaler
{
    public class MapView : MonoBehaviour
    {
        public bool IsOpened => gameObject.IsActive();

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        public void SelectNextLevel()
        {
            CreateEntity.OneFrame()
                .Add<SelectNextLevel>()
                ;
        }
    }
}