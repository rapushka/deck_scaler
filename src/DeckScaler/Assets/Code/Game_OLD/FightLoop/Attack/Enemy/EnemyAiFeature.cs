namespace DeckScaler
{
    public sealed class EnemyAiFeature : Feature
    {
        public EnemyAiFeature()
            : base(nameof(EnemyAiFeature))
        {
            Add(new OnEnemyTurnStartedEndTurn());
        }
    }
}