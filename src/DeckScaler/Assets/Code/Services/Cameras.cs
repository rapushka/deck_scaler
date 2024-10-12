using System;
using UnityEngine;

namespace DeckScaler.Service
{
    public class Cameras
    {
        public Cameras(Data data)
        {
            MainCamera = data.MainCamera;
            UiCamera = data.UiCamera;
        }

        public Camera MainCamera { get; }
        public Camera UiCamera   { get; }

        [Serializable]
        public class Data
        {
            public Camera MainCamera;
            public Camera UiCamera;
        }
    }
}