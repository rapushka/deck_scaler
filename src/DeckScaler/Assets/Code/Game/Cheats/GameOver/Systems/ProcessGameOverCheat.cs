using DeckScaler.Cheats.Component;
using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler.Cheats.Systems
{
    public class ProcessGameOverCheat : ProcessCheatBaseSystem<GameOver>
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        protected override bool TryProcess(Entity<Scopes.Cheats> entity, GameOver component)
        {
            UiMediator.GameOver();
            return true;
        }
    }
}