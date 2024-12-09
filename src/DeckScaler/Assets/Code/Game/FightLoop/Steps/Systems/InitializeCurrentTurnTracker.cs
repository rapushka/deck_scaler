using DeckScaler.Component;
using Entitas;

namespace DeckScaler.Systems
{
    public class InitializeCurrentTurnTracker : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .Add<DebugName, string>("turn tracker")
                .Add<TurnTracker>()
                .Add<WaitingForAnimations>()
                ;
        }
    }
}