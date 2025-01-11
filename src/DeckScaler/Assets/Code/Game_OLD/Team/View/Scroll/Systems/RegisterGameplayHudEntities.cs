using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public class RegisterGameplayHudEntities : IInitializeSystem
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static GameplayHUD HUD => UiMediator.GetCurrentScreen<GameplayHUD>();

        private static IFactories Factory => ServiceLocator.Resolve<IFactories>();

        public void Initialize()
        {
            foreach (var entityBehaviour in HUD.Behaviours)
                Factory.EntityBehaviour.Register(entityBehaviour);
        }
    }
}