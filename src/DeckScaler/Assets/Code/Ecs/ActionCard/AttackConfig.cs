using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public struct AttackConfig
    {
        [field: SerializeField] public float Multiplier { get; private set; }
        [field: SerializeField] public Suit  TargetSuit { get; private set; }
    }
}