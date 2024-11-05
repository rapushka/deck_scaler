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
            public Args(string unitID, Side side)
            {
                ID = unitID;
                Side = side;
            }

            [field: SerializeField] public string ID   { get; private set; }
            [field: SerializeField] public Side   Side { get; private set; }

            public void Deconstruct(out string id, out Side type)
            {
                id = ID;
                type = Side;
            }
        }
    }

    public sealed class UnitSpawned : ValueComponent<Entity<Model>>, IInScope<Model> { }
}