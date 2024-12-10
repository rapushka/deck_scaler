using DeckScaler.Service;
using UnityEngine;

namespace DeckScaler
{
    public class AutoBootstrap : MonoBehaviour
    {
        [SerializeField] private Configs _configs;

        private void Awake()
        {
            var gameRunner = new GameRunner(_configs);
            gameRunner.StartGame();
        }
    }
}