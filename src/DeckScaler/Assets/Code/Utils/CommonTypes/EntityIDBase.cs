using System;

namespace DeckScaler
{
    [Serializable]
    public abstract class EntityIDBase
    {
        protected static int Counter;
        public int ID { get; protected set; }

        public static implicit operator int(EntityIDBase entityIDBase) => entityIDBase.ID;

        public override string ToString() => ID.ToString();
    }

    [Serializable]
    public class EntityModelIDBase : EntityIDBase
    {
        public static EntityModelIDBase Next() => new() { ID = Counter++ };
    }

    [Serializable]
    public class EntityViewIDBase : EntityIDBase
    {
        public static EntityViewIDBase Next() => new() { ID = Counter++ };
    }
}