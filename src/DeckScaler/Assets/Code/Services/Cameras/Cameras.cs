using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DeckScaler.Service
{
    public interface ICameras : IService
    {
        void SpawnCameras();

        Camera MainCamera { get; }
        Camera UiCamera   { get; }
    }

    [Serializable]
    public class Cameras : ICameras
    {
        [SerializeField] private CamerasDirector _camerasPrefab;

        private CamerasDirector _cameras;

        public void SpawnCameras()
        {
            _cameras = Object.Instantiate(_camerasPrefab);
        }

        public Camera MainCamera => _cameras.MainCamera;

        public Camera UiCamera => _cameras.UiCamera;
    }
}