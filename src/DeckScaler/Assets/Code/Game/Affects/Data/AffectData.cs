using System;
using DeckScaler.Component;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class AffectData
    {
        [field: SerializeField] public AffectType Type  { get; private set; }
        [field: SerializeField] public int        Value { get; private set; }

        public AffectData(AffectType type, int value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString() => $"{nameof(Type)}: {Type}, {nameof(Value)}: {Value}";
    }
}