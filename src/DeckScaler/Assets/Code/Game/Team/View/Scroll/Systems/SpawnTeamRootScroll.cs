using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
{
    public class SpawnTeamRootScroll : IInitializeSystem
    {
        private static GameplayHUD HUD => Services.Get<IUI>().GetScene<GameplayHUD>();

        private static IFactories Factory => Services.Get<IFactories>();

        public void Initialize()
        {
            Factory
                .SetupEntityBehaviour(HUD.TeamScroll)
                .Add<Name, string>("scroll team root")
                .Is<TeamRootScroll>(true)
                ;
        }
    }
}