using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
{
    public class SpawnGameplayHudEntities : IInitializeSystem
    {
        private static GameplayHUD HUD => Services.Get<IUI>().GetScene<GameplayHUD>();

        private static IFactories Factory => Services.Get<IFactories>();

        public void Initialize()
        {
            foreach (var entityBehaviour in HUD.Behaviours)
                Factory.SetupEntityBehaviour(entityBehaviour);
        }
    }
}