using System;
using DeckScaler.Component;

namespace DeckScaler
{
    [Serializable]
    public struct EntityID
        : IEquatable<EntityID>
    {
        private static int _globalCounter;

        public int ID { get; private set; }

        public static implicit operator int(EntityID entityID) => entityID.ID;

        public static bool operator ==(EntityID lhs, EntityID rhs) => lhs.Equals(rhs);
        public static bool operator !=(EntityID lhs, EntityID rhs) => !(lhs == rhs);

        public static EntityID Next() => new() { ID = _globalCounter++ };

        public override string ToString()
            => $"{ID} {EntityName}";

        private string EntityName
            => this.GetEntityOrDefault()?.GetOrDefault<DebugName, string>("no name")
                ?? "Entity is destroyed:(";

        public override bool Equals(object obj) => obj is EntityID other && Equals(other);

        public bool Equals(EntityID other) => GetHashCode() == other.GetHashCode();

        public override int GetHashCode() => ID;
    }
}