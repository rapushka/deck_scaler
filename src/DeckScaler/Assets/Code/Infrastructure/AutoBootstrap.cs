using UnityEngine;

namespace DeckScaler
{
    public class AutoBootstrap : MonoBehaviour
    {
        [SerializeField] private ServicesData _servicesData;

        private void Awake()
        {
            var gameRunner = new GameRunner(_servicesData);
            gameRunner.SetupServices();

            gameRunner.StartGame();
        }
    }
}