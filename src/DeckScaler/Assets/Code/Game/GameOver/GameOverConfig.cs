using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class GameOverConfig
    {
        [field: SerializeField] public float DelayBeforeGameOverScreenAppear { get; private set; }
    }
}