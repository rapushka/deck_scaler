namespace DeckScaler
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature()
            : base(nameof(MovementFeature))
        {
            Add(new MoveWorldPosition());

            Add(new CleanupMoves());
        }
    }
}