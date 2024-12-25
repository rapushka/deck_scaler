using DeckScaler.Service;

namespace DeckScaler
{
    public class SkipStageButton : BaseButton
    {
        private static StagesUtil StageUtils => ServiceLocator.Resolve<IUtils>().Stages;

        protected override void OnClick() => StageUtils.CompleteCurrentStage();
    }
}