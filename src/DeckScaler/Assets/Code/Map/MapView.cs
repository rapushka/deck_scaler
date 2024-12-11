using DeckScaler.Component;
using UnityEngine;

namespace DeckScaler
{
    public class MapView : MonoBehaviour
    {
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