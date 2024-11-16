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

        public static implicit operator UnitIDRef(string unitID)
        {
            return new UnitIDRef { Value = unitID };
        }
    }
}