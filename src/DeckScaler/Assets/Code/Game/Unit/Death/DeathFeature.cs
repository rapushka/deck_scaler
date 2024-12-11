using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class DeathFeature : Feature
    {
        public DeathFeature()
            : base(nameof(DamageFeature))
        {
            Add(new MarkDeadUnitsWithZeroHp());

            Add(new FillFreedTeamSlotsFeature());
            Add(new CompleteLevelIfAllEnemiesDied());
            Add(new GameOverFeature());

            Add(new DestroyJustDiedUnits());
            Add(new EndDeathProcessing());
        }
    }
}