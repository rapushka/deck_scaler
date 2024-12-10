using System;
using DeckScaler.Service;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class ServicesData
    {
        [field: SerializeField] public Cameras.Data CamerasData { get; private set; }
        [field: SerializeField] public Configs      Configs     { get; private set; }
    }
}