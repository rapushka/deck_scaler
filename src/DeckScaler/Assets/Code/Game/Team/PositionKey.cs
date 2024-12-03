namespace DeckScaler
{
    public readonly struct PositionKey
    {
        public readonly Side Side;
        public readonly int Index;

        public PositionKey(Side side, int index)
        {
            Side = side;
            Index = index;
        }

        public static implicit operator PositionKey((Side Side, int Index) tuple)       => new(tuple.Side, tuple.Index);
        public static implicit operator (Side Side, int Index)(PositionKey positionKey) => (positionKey.Side, positionKey.Index);
    }
}