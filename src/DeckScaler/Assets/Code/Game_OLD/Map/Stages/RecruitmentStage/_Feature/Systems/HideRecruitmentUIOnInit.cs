using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public sealed class HideRecruitmentUIOnInit : IInitializeSystem
    {
        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        public void Initialize()
        {
            HUD.RecruitmentStageView.SetActive(false);
        }
    }
}