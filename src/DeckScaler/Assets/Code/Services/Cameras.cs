using System;
using UnityEngine;

namespace DeckScaler.Service
{
    public interface ICameras : IService
    {
        Camera MainCamera { get; }
        Camera UiCamera   { get; }
    }

    public class Cameras : ICameras
    {
        public Cameras(Services.Data data)
        {
            MainCamera = data.CamerasData.MainCamera;
            UiCamera = data.CamerasData.UiCamera;
        }

        public Camera MainCamera { get; }

        public Camera UiCamera { get; }

        [Serializable]
        public class Data
        {
            public Camera MainCamera;
            public Camera UiCamera;
        }
    }
}