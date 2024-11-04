using System;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Component
{
    public sealed class SpawnUnit : ValueComponent<SpawnUnit.Args>, IInScope<Model>
    {
        [Serializable]
        public class Args
        {
            public Args(string unitID, UnitType type)
            {
                ID = unitID;
                Type = type;
            }

            [field: SerializeField] public string   ID   { get; private set; }
            [field: SerializeField] public UnitType Type { get; private set; }
        }
    }
}