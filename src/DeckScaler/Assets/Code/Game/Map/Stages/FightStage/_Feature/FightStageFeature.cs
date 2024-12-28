using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class FightStageFeature : Feature
    {
        public FightStageFeature()
            : base(nameof(FightStageFeature))
        {
            Add(new HideFightStageUIOnInit());

            Add(new UpdateFightStageStageUI());
            Add(new HideFightStageUIOnStageCompleted());
        }
    }
}