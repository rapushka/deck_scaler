using System;
using SmartIdTable;

namespace DeckScaler
{
    // Some wrappers to use IdRef keys in collections

    [Serializable]
    public struct ReferenceIDRef
    {
        [IdRef]
        public string Value;
    }

    [Serializable]
    public struct UnitIDRef
    {
        [IdRef(startsWith: Constants.TableID.Units)]
        public string Value;

        public static implicit operator UnitIDRef(string unitID) => new() { Value = unitID };
    }

    [Serializable]
    public struct TrinketIDRef
    {
        [IdRef(startsWith: Constants.TableID.Trinkets)]
        public string Value;

        public static implicit operator TrinketIDRef(string trinketID) => new() { Value = trinketID };
    }
}