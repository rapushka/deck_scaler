using System;

namespace DeckScaler
{
    [Serializable]
    public struct EntityID
    {
        private static int _globalCounter;

        public int ID { get; private set; }

        public static implicit operator int(EntityID entityID) => entityID.ID;

        public static EntityID Next() => new() { ID = _globalCounter++ };

        public override string ToString() => ID.ToString();
    }
}